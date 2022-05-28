using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float jumpForce = 150.0f;
    public float speed = 1.0f;
    public float moveDirection;
    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigidbody2D;
    private Animator anim;
    private SpriteRenderer _spriteRenderer;
    public bool sagaBakma;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);
        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                //_spriteRenderer.flipX = true;
                Vector3 scaleChange = transform.localScale;
                scaleChange = new Vector3(-1f, 1f, transform.localScale.z);
                transform.localScale = scaleChange;
                anim.SetFloat("speed", speed);
                sagaBakma = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                //_spriteRenderer.flipX = false;
                Vector3 scaleChange = transform.localScale;
                scaleChange = new Vector3(1f, 1f, transform.localScale.z);
                transform.localScale = scaleChange;
                anim.SetFloat("speed", speed);
                sagaBakma = true;
            }
        }
        else if(grounded == true)
        {
                moveDirection = 0.0f;
                anim.SetFloat("speed",0.0f);
        }
        if(grounded == true && Input.GetKey(KeyCode.W))
        {
                jump = true;
                grounded = false;
                anim.SetTrigger("jump");
                anim.SetBool("grounded",false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            anim.SetBool("grounded",true);
            grounded = true;
        }
    }
    
}