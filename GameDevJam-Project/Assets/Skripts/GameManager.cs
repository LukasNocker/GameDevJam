using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        //SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        //if(PauseMenu.isPaused)
    }
    // Ressources
  
    public List<int> SoulTable;
    public List<int> xpTable;

    //References
    public Player player;

    //public floating text
    public FloatingTextManager floatingTextManager;

    //Logic
    public float souls;
    public float maxSouls;

    
    //Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            SaveState();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            LoadState();
        }
    }
    public void SaveState()
    {

        PlayerPrefs.SetString("SaveState", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("Player_position_x", CharakterController.instance.transform.position.x);
        PlayerPrefs.SetFloat("Player_position_y", CharakterController.instance.transform.position.y);
        PlayerPrefs.SetFloat("Player_position_z", CharakterController.instance.transform.position.z);
        PlayerPrefs.SetFloat("Player_Souls_Collected", souls);
        Debug.Log("SaveState");

    }

    // public void LoadState(Scene s, LoadSceneMode mode)
    public void LoadState()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("SaveState"));
        CharakterController.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("Player_position_x"),PlayerPrefs.GetFloat("Player_position_y"),PlayerPrefs.GetFloat("Player_position_z"));
        souls = PlayerPrefs.GetFloat("Player_Souls_Collected");

    }
    public void PickupSoul()
      {
          ++souls;
      }
        
    
}
