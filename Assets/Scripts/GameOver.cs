using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        DialogBox.shared.AppearWithText("You have reached the end of the game! Thanks for playing!");

        Time.timeScale = 0.1f;


        Invoke("ChangeScene", 1);

    }

    void ChangeScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
}
