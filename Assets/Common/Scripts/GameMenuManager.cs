using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    public KeyCode pauseGameKey = KeyCode.Escape;
    public GameObject pauseMenu;
    
    private static bool isPaused = false;

    public static bool GameIsPaused()
    {
        return isPaused;
    }


    void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(pauseGameKey))
        {
            // LESSON 3-1: Add code below.
            if(isPaused == false)
            {
                Time.timeScale = 0;
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
