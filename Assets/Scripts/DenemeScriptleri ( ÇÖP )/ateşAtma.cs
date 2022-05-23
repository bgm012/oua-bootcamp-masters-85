using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ateşAtma : MonoBehaviour
{
    public GameObject player;
    public GameObject fireBallPrefab;
    public GameObject asa;

    public float fireBallSpeed = 7.0f;

    private Vector3 target;

    private void Start()
    {
    }

    private void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 270.0f;
        //player.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBall(direction,rotationZ);
        }

    }

    void fireBall(Vector2 direction,float rotationZ)
    {
        GameObject x = Instantiate(fireBallPrefab) as GameObject;
        x.transform.position = asa.transform.position;
        x.transform.rotation = quaternion.Euler(0.0f, 0.0f, z: rotationZ);
        x.GetComponent<Rigidbody2D>().velocity = direction * fireBallSpeed;
    }
}
