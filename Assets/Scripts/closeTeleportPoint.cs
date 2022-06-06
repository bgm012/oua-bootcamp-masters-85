using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeTeleportPoint : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void close()
    {
        _spriteRenderer.enabled = false;
    }

    public void open()
    {
        _spriteRenderer.enabled = true;
    }
}
