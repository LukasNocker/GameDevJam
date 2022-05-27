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
        SceneManager.sceneLoaded += LoadState;
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
    public int souls;
    public int experience;
    
    //Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }

    //Save State
    /*
     * INT preferedSkin
     * INT pesos
     * INT experience
     * INT weaponLevel
     */
    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += souls.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);

        Debug.Log("SaveState");

    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //change player skin
        souls = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //change the weapon Level 

        Debug.Log("LoadState");
    }

    //Souls collecting [not working yet]

    public void UpdateSoulDisplayUI()
    {
        ++souls;

    }
    public void PickupSoul()
      {
          ++souls;
      }
        
    
}
