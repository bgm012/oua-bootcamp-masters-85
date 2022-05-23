using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class fireBall : MonoBehaviour {

    public int damage = 40;
    private Rigidbody2D rb;
    //public GameObject impactEffect;
    
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    /*private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }*/

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (hitInfo.gameObject.CompareTag("ground") || hitInfo.gameObject.CompareTag("enemy") || hitInfo.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
    }
	
}