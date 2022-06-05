using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public GameObject Player;
    public Animator animator;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        /*if(col.CompareTag("Player"))
        {
            Player player = col.GetComponent<Player>();
            smallEnemy2 smallEnemy = col.GetComponent<smallEnemy2>();
            controller controller = col.GetComponent<controller>();
            if (player != null && smallEnemy != null)
            {
               //player.takeHit(smallEnemy.damage);
               Debug.Log(smallEnemy.damage);
            }
        }*/
        if (col.CompareTag("Player"))
        {
            if (Player != null)
            {
                animator.SetBool("damage",true);
                StartCoroutine(wait());
                Player.GetComponentInChildren<Player>().takeHit(20);
                animator.SetBool("damage",false);
            }
        }
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
