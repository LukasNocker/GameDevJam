using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    private bool inOverworld;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        inOverworld = false;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (inOverworld)
        {
            currentTime -= 1 * Time.deltaTime;
            GameManager.instance.souls = currentTime;
            if (currentTime == 0)
            {
                inOverworld = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Ghetto_2");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            inOverworld = true;
        }
    }
}

