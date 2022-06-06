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
    
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        havaBekcisi havaBekcisi = hitInfo.GetComponent<havaBekcisi>();
        suBekcisi suBekcisi = hitInfo.GetComponent<suBekcisi>();
        toprakBekcisi toprakBekcisi = hitInfo.GetComponent<toprakBekcisi>();
        smallEnemy2 _smallEnemy2 = hitInfo.GetComponent<smallEnemy2>();
        
        if (havaBekcisi != null)
        {
            havaBekcisi.TakeDamage(damage);
        }
        if (suBekcisi != null)
        {
            suBekcisi.TakeDamage(damage);
        }  
        if (toprakBekcisi != null)
        {
            toprakBekcisi.TakeDamage(damage);
        }
        if (_smallEnemy2 != null)
        {
            _smallEnemy2.TakeDamage(damage);
        }

        if (hitInfo.gameObject.CompareTag("ground") || hitInfo.gameObject.CompareTag("enemy") || hitInfo.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
	
}