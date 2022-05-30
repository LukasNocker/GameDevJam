using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string sceneNames;
    public string areaTransitionName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //teleport the player
            GameManager.instance.SaveState();
            string sceneName = sceneNames;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            CharakterController.instance.areaTransitionName = areaTransitionName;
        }
    }
}

