using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sayfaToplama : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (col.CompareTag("Player"))
        {
            player.suBilgisi = true;
            Destroy(gameObject);
        }
    }
}
