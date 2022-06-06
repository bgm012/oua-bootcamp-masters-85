using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suSayfasıToplama : MonoBehaviour
{
    public Image su;
    public Image suParsomen;
    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (col.CompareTag("Player"))
        {
            player.suBilgisi = true;
            su.enabled = true;
            suParsomen.enabled = true;
            Destroy(gameObject);
        }
    }
}
