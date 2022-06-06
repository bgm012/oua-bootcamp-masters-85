using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    [SerializeField] GameObject ui_credits;
    public void CreditsOpen()
    {
        ui_credits.SetActive(true);
    }

    public void BUttonileri()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Evet()
    {
        SceneManager.LoadScene(2);
    }

    public void Hayir()
    {
        SceneManager.LoadScene(0);
    }
}
