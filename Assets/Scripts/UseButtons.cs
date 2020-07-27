using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseButtons : MonoBehaviour
{
    public GameObject panel;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void displayPanel()
    {
        panel.SetActive(true);
    }

    public void closePanel()
    {
        panel.SetActive(false);
    }
}
