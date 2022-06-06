using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

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
    public bool havaBilgisi = false;
    public bool atesBilgisi = true;
    public bool toprakBilgisi = false;
    private Animator _animator;
    public SpriteRenderer deneme;
    public Image atesHava;
    public Image atesToprak;
    public Image suHava;
    public Image suToprak;
    public TextMeshProUGUI text;
    public healtBar healtBar;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        healtBar.SetMaxHealt(health);
    }

    private void Update()
    {
        if (health<=0)
        {
            SceneManager.LoadScene("kaybettin");
        }
        if (Time.time > nextFireTime)
        {
            if (Input.GetKey(KeyCode.E) && firstButtonPressed)
            {
                if (Time.time - timeOfFirstButton < 2.0f)
                {
                    _animator.SetBool("teleport",true);
                    nextFireTime = Time.time + coolDownTime;
                    deneme.enabled = false;
                }
                reset = true;
            }
            if (Input.GetKey(KeyCode.T) && !firstButtonPressed && havaBilgisi)
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
        control();
        text.text = "Mevcut Can % lik Değeri: " + (health/3f).ToString();
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
        healtBar.SetHealth(health);

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

    public void AnimationStart()
    { 
        playerTeleport(distance);
        _animator.SetBool("teleport",false);
    }

    public void backIdle()
    {
        _animator.SetTrigger("backIdle");
    }

    void control()
    {
        if (havaBilgisi && atesBilgisi)
        {
            atesHava.enabled = true;
        }
        if (havaBilgisi && suBilgisi)
        {
            suHava.enabled = true;
        }
        if (atesBilgisi && toprakBilgisi)
        {
            atesToprak.enabled = true;
        }

        if (toprakBilgisi && suBilgisi)
        {
            suToprak.enabled = true;
        }
    }
}
