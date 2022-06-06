using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suBekcisiHitbox : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            if (Player != null)
            {
                Player.GetComponentInChildren<Player>().takeHit(GetComponentInParent<suBekcisi>().damage);
            }
        }
        
    }
}
