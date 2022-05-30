using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    private bool inOverworld;
    // Start is called before the first frame update
    void Start()
    {
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

    public void StartTimer()
    {
        inOverworld = true;
    }
}
