using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

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


    private void Update()
    {

        if (Time.time > nextFireTime)
        {
            if (Input.GetKey(KeyCode.E) && firstButtonPressed)
            {
                if (Time.time - timeOfFirstButton < 0.5f)
                {
                    playerTeleport(distance);
                    nextFireTime = Time.time + coolDownTime;
                }
                reset = true;
            }
            if (Input.GetKey(KeyCode.T) && !firstButtonPressed)
            {
                firstButtonPressed = true;
                timeOfFirstButton = Time.time;
            }
            if (reset)
            {
                firstButtonPressed = false;
                reset = false;
            }
        }
    }

    /*public void takeDamage()
    {   
    }*/

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
        //float tempX = distance * yön;
    }
}
