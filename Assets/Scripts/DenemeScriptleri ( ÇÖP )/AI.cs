using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private BoxCollider2D _boxCollider2D; //Trigger Area Colliderı
    public bool yurumeIznı = false;
    private Animator _animator;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private GameObject yön;
    private float kıyaslamaX = 0.0f;
    private bool sagaYürüme ;
    //private bool attack = false;
    //[SerializeField] private BoxCollider2D denemebir;
    //[SerializeField] private CircleCollider2D denemeiki;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //denemebir = GetComponent<BoxCollider2D>();
        //denemeiki = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        kıyaslamaX = yön.transform.position.x;
        if (yurumeIznı)
        {
            _animator.SetBool("canWalk", true);
            if (kıyaslamaX > _rigidbody2D.transform.position.x)
            {
                sagaYürüme = true;
            }
            if(kıyaslamaX < _rigidbody2D.transform.position.x)
            {
                sagaYürüme = false;
            }
        }
        if(!yurumeIznı)
        {
            _animator.SetBool("canWalk", false);
        }
    }

    private void FixedUpdate()
    {
        if (yurumeIznı && sagaYürüme)
        {
            Flip_Right();
            _rigidbody2D.velocity = new Vector2( speed , y:_rigidbody2D.velocity.y);
        }
        if (yurumeIznı && !sagaYürüme)  
        {
            Flip_Left();
            _rigidbody2D.velocity = new Vector2( -speed , y:_rigidbody2D.velocity.y);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            yurumeIznı = true;
        }
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && attack)
        {
            yurumeIznı = false;
            attack = false;
        }
    }*/

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            yurumeIznı = false;
        }
    }
    void Flip_Right()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Flip_Left()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    /*void Attack()
    {
        
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider)
        {
            attack = true;
            _animator.SetBool("attack",true);
        }
    }*/
}
