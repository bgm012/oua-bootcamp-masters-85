using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class toprakSayfaToplama : MonoBehaviour
{
    public Image toprak;
    public Image toprakParsomen;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (col.CompareTag("Player"))
        {
            player.toprakBilgisi = true;
            toprak.enabled = true;
            toprakParsomen.enabled = true;
            Destroy(gameObject);
        }
    }
}
