using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGamePvP()
    {
        SceneManager.LoadScene("PvP");
    }

    public void PlayGamePvAI()
    {
        SceneManager.LoadScene("PvAI");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!"); //Just for Unity
        Application.Quit();
    }
}
