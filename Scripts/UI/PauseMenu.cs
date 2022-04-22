using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;

    public static bool Settings = false;

    public void LoadMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public bool getPause()
    {
        return GameisPaused;
    }

    public GameObject settingsMenuUI;
    public void SettingsMenu()
    {
        settingsMenuUI.SetActive(true);
        Settings = true;
    }

    public void Back_Button()
    {
        settingsMenuUI.SetActive(false);
        Settings = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
    public void Return()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Settings == false)
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
