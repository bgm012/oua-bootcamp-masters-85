using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health;
    public Transform _transform;
    public float distance;
    public float coolDownTime = 3.0f;
    private float nextFireTime = 0.0f;
    private bool firstButtonPressed = false;
    public float timeOfFirstButton;
    private bool reset = false;
    public bool takeDamage = false;
    public bool suBilgisi = false;
    private Animator _animator;
    public SpriteRenderer deneme;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Time.time > nextFireTime)
        {
            if (Input.GetKey(KeyCode.E) && firstButtonPressed)
            {
                if (Time.time - timeOfFirstButton < 2.0f)
                {
                    //playerTeleport(distance);
                    _animator.SetBool("teleport",true);
                    nextFireTime = Time.time + coolDownTime;
                    deneme.enabled = false;
                }
                reset = true;
            }
            if (Input.GetKey(KeyCode.T) && !firstButtonPressed)
            {
                deneme.enabled = true;
                firstButtonPressed = true;
                timeOfFirstButton = Time.time;
            }
            if (Time.time - timeOfFirstButton > 2.0f)
            {
                deneme.enabled = false;
                reset = true;
            }
            if (reset)
            {
                firstButtonPressed = false;
                reset = false;
            }
        }
    }


    void playerTeleport(float distance)
    {
        controller _controller = GetComponent<controller>();
        bool sagaBakma = _controller.sagaBakma;
        if (sagaBakma)
        {
            _transform.position = new Vector3(transform.position.x + distance, _transform.position.y,0);
        }
        if (!sagaBakma)
        {
            _transform.position = new Vector3(transform.position.x - distance, _transform.position.y,0);
        }
        //float tempX = distance * yön;
    }

    public void takeHit(float smallEnemyDamage)
    {
        _animator.SetBool("damage",true);
        health -= smallEnemyDamage;
        if (health <= 0)
        {
            Die();
        }

        if (health > 0)
        {
            StartCoroutine(sleep());
        }

    }
    public void Die ()
    {
        controller controller = GetComponent<controller>();
        if (controller != null)
        {
            controller.die = true;
            Debug.Log(controller.die);
        }
    }

    IEnumerator sleep()
    {
        yield return new WaitForSeconds(1.0f);
        _animator.SetBool("damage",false);
    }

    /* teleportStartSleep()
    {
        yield return new WaitForSeconds();
    }
    
    IEnumerator teleportFinishSleep()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
    }*/

    public void AnimationStart()
    { 
        playerTeleport(distance);
        _animator.SetBool("teleport",false);
    }

    public void backIdle()
    {
        _animator.SetTrigger("backIdle");
    }
}
