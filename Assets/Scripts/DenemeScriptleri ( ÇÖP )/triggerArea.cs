using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArea : AI
{
    [SerializeField] private BoxCollider2D _boxCollider2D;

    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            yurumeIznı = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            yurumeIznı = false;
        }
    }
}
