using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject CreditsScreen;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void OpenCredits()
    {
        if (CreditsScreen != null)
        {
            CreditsScreen.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
