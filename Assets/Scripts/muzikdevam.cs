using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class muzikdevam : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if ((SceneManager.GetActiveScene().buildIndex == 2))
        {
            Destroy(this.gameObject);
        }
    }
}
