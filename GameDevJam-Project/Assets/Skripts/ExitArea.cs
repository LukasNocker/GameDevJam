using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    // This can be used as a component for the "door" to move bewteen scenes.
    public string areaToLoad;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player")
        {
            SceneManager.LoadScene(areaToLoad);
        }
    }
}
