using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sayfaToplama : MonoBehaviour
{
    [SerializeField] GameObject sayfa;
    [SerializeField] int toplanansayfa=-1;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (col.CompareTag("Player"))
        {
            player.suBilgisi = true;
            toplanansayfa++;
            sayfa.gameObject.transform.GetChild(toplanansayfa).gameObject.SetActive(true);
            Destroy(gameObject);
            
        }
    }
}
