using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healtBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;


    public void SetMaxHealt(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
