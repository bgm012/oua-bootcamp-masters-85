using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class smallEnemy2 : MonoBehaviour {

    public float health = 80f;
    public float damage = 10f;
    [SerializeField] private Animator _animator;
    //public AnimationClip deathEffect;
    //public AnimationClip takeDamageEffect;
    public GameObject player;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    

    public void TakeDamage (int damage)
    {
        if (player != null && player.GetComponent<Player>().atesHava)
        {
            health -= damage;
        }
        if (player != null && !player.GetComponent<Player>().atesHava)
        {
            health -= (damage*0.1f);
        }
        smallEnemy enemy = GetComponent<smallEnemy>();
        if (health > 0)
        {
            StartCoroutine(TakeHit());
            StartCoroutine(Sleep());
        }
        if (health <= 0)
        {
            enemy.live = false;
            Die();
        }
    }

    public void Die ()
    {
        //float delay = 0.35f;
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        _animator.SetBool("canWalk",false);
        _animator.SetBool("Attack",false);
        _animator.SetBool("die",true);
        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
    }

    IEnumerator TakeHit()
    {
        //Instantiate(takeDamageEffect, transform.position, Quaternion.identity);
        _animator.SetBool("canWalk",false);
        _animator.SetBool("Attack",false);
        yield return new WaitForSeconds(0.25f);
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(0.25f);
    }

}