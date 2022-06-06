using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class suBekcisi : MonoBehaviour {

    public float health = 300f;
    public float damage = 30f;
    private Animator _animator;
    public GameObject player;
    private bool bilgiControl;

    private void Start()
    {
        bilgiControl = player.GetComponent<Player>().atesBilgisi && player.GetComponent<Player>().havaBilgisi;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage (int damage)
    {
        if (player != null && bilgiControl )
        {
            health -= damage;
        }
        else if (player != null && !bilgiControl )
        {
            health -= (damage * 0.1f);
        }
        
        Enemy_AI enemy = GetComponent<Enemy_AI>();
        
        if (health > 0)
        {
            enemy.takeDamage = true;
            StartCoroutine(TakeHit());
            StartCoroutine(Sleep());
            enemy.takeDamage = false;
        }
        if (health <= 0)
        {
            enemy.live = false;
            Die();
        }
    }

    public void Die ()
    {
        float delay = 1.2f;
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        _animator.SetBool("canWalk",false);
        _animator.SetBool("Attack",false);
        _animator.SetBool("die",true);
        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length + delay);
    }

    IEnumerator TakeHit()
    {
        //Instantiate(takeDamageEffect, transform.position, Quaternion.identity);
        _animator.SetBool("canWalk",false);
        _animator.SetBool("Attack",false);
        _animator.SetBool("damage",true);
        yield return new WaitForSeconds(0.25f);
        _animator.SetBool("damage",false);
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(0.25f);
    }

}