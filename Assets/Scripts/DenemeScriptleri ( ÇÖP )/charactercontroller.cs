using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 10f;
    [SerializeField] float jumpforce = 15f;
    [SerializeField] float movehorizontal;

    [SerializeField] int jumpcounter = 0;
    [SerializeField] int maxjump = 1;

    [SerializeField] Animator _anim;
    [SerializeField] bool grounded = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
        jumpcounter = maxjump;
    }

    private void Update()
    {
        movehorizontal = Input.GetAxis("Horizontal");

        if (movehorizontal > 0.1f && grounded)
        {
            _anim.SetFloat("speed", 1);
        }
        if (movehorizontal < -0.1f && grounded)
        {
            _anim.SetFloat("speed", 1);
        }
        if (movehorizontal == 0 && grounded)
        {
            _anim.SetFloat("speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpcounter >= 1)
        {
            grounded = false;
            _anim.SetBool("grounded", false);
            _anim.SetBool("jump", true);
            jumpcounter--;

            _rb.velocity = new Vector2(_rb.velocity.x, jumpforce);
        }
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Flip_Right();
            _rb.velocity = new Vector2(movehorizontal * _speed, _rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Flip_Left();
            _rb.velocity = new Vector2(movehorizontal * _speed, _rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            _anim.SetBool("jump", false);
            _anim.SetBool("grounded", true);
            grounded = true;
            jumpcounter = maxjump;
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
}
