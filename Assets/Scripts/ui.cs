using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    [SerializeField] GameObject uipanel;
    [SerializeField] GameObject uipanel2;
    [SerializeField] bool tab_counter=false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //Debug.Log("aa");
            tab_counter = true;

            uipanel.SetActive(true);
            uipanel2.SetActive(true);  
        }
        if (tab_counter && Input.GetKey(KeyCode.G))
        {
            //Debug.Log("bb");
            tab_counter = false;
            uipanel.SetActive(false);
            uipanel2.SetActive(false);
        }
    }
}
