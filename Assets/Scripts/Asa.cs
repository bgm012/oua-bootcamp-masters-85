using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asa : MonoBehaviour {

    public Transform firePoint;
    public GameObject fireballPrefab;
    public float speed;
    public float playTime;
    public float coolDownTime = 1.0f;
    private float nextFireTime = 0.0f;
    void Update ()
    {
        Vector2 asaPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - asaPosition;
        transform.right = direction;
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Shoot());
                nextFireTime = Time.time + coolDownTime;
            }
        }
    }

    IEnumerator Shoot ()
    {
        GameObject newFireBall = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        newFireBall.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        yield return new WaitForSeconds(playTime);
        Destroy(newFireBall);
    }
    
}