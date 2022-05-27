using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //I made it static so I do not have to create a PauseMenu object
    public static bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void SaveGame()
    {
        Debug.Log("You saved your game, maybe!");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You're a quitter!");
    }
}
