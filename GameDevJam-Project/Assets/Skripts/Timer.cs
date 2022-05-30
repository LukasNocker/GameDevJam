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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
            
        {
            currentTime = GameManager.instance.souls;
            inOverworld = true;
            StartCoroutine(CountdownToStart());
        }
    }

    IEnumerator CountdownToStart()
{
    while (currentTime > 0)
    {
        yield return new WaitForSeconds(1f);
        currentTime--;
        GameManager.instance.souls = currentTime;
        if (currentTime == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Ghetto_2");
                inOverworld = false;
            }
    }
}
}

