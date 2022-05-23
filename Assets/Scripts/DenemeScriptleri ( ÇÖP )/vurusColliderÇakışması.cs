using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vurusColliderÇakışması : MonoBehaviour
{
     [SerializeField] private Animator _animator;
     [SerializeField] private CircleCollider2D _circleCollider2D;
     private void Start()
     {
          _animator = GetComponent<Animator>();
          _circleCollider2D = GetComponent<CircleCollider2D>();
     }

     private void OnTriggerEnter2D(Collider2D col)
     {
          if (col.GetType() == typeof(CircleCollider2D))
          {
               _animator.SetBool("attack",true);
               _animator.SetBool("canWalk",false);
          }
     }
}
