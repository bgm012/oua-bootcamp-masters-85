using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeTeleportPoint : MonoBehaviour
{
    private GameObject _teleportPoint;

    
    public void close()
    {
        _teleportPoint.SetActive(false);
    }

    public void open()
    {
        _teleportPoint.SetActive(true);
    }
}
