using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
  {
      SceneManager.LoadScene("Intro");

  }
  public void QuitGame()
  {
      Application.Quit();

  }
  public void LoadGame()
  {
    GameManager.instance.LoadState();
  }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");

    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");

    }
}
