using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
public string dialog;
public Text dialogText;
public GameObject dialogBox;
public GameObject npcImage;
private BoxCollider2D boxCollider;
public bool playerInRange;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        dialogBox.SetActive(false);
    }

        // Collison work
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                Debug.Log("player in range");
                
                {
                    //if (dialogBox.activeInHierarchy)
                    //{
                    //    dialogBox.SetActive(false);

                   // }
                   // else
                   // {
                        dialogBox.SetActive(true);
                        dialogText.text = dialog;
                   // }
                }
            }
        }
    
   
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            Debug.Log("player not in range");
        }
    }
}
