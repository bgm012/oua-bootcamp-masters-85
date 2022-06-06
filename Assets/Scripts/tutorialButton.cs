using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Image _ımage;

    public void pressButton()
    {
        _ımage.enabled = true;
        StartCoroutine(sleep());
    }

    IEnumerator sleep()
    {
        yield return new WaitForSeconds(10f);
        _ımage.enabled = false;
    }
}