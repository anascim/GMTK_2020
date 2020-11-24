using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource music;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void MuteAudio()
    {
        if (music.volume == 0f)
            music.volume = 1f;
        else
            music.volume = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
