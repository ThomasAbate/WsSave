using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }
    public void PauseGame()
    {
        
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        
    }

    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }
}
