using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /***************************************************************************************
* Title: Pause Menu
* Author: Brackeys
* Date: 2017
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=JivuXdrIHK0
***************************************************************************************/

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject gameManger;
    private GameManager _gameManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }

    public void Restart()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
