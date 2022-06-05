using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public GameObject enemy;
    
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            enemy.GetComponent<smallEnemy>().target = trig.transform;
            enemy.GetComponent<smallEnemy>().inRange = true;
            enemy.GetComponent<smallEnemy>().Flip(); 
        }
    }
}
