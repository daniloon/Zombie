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
    public GameObject ControlsMenu;

    //Action at start of Script
    void Start()
    {
        pauseMenuUI.SetActive(false);
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
        ControlsMenu.SetActive(false);
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

    //Gets into the main 
    public void LoadControls()
    {
        if (ControlsMenu != null)
        {
            ControlsMenu.SetActive(true);
            pauseMenuUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    //Code for getting back to pause menu
    public void PauseBack()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            ControlsMenu.SetActive(false);
        }
    }

    //Actions to go back to Main Menu
    public void LoadMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
    }

    // Pause Menu's "Quit" Button
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
       
    }
}
