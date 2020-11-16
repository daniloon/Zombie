using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public UnityEvent onPause = new UnityEvent();
    public UnityEvent onResume = new UnityEvent();
    public GameObject pauseMenuUI;
    public GameObject ControlPanel;

    //Action at start of Script
    void Start()
    {
        pauseMenuUI.SetActive(false);
        ControlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Events if game is paused or not
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }      
    }

    //Actions that happen when Resume/Escape Button are pressed
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        onResume.Invoke();
    }
    //Actions that happen when game is paused
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        onPause.Invoke();
    }

    public void LoadControls()
    {
        ControlPanel.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void BackControls()
    {
        ControlPanel.SetActive(false);
        Pause();
    }

    //Actions to go back to Main Menu
    public void LoadMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
    }

    //Code for Pause Menu's "Quit" Button
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
       
    }
}
