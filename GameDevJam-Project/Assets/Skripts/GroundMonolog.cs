using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonolog : MonoBehaviour
{
// Start is called before the first frame update
public string dialog;
public Dialogue dialogue; 
//public Text dialogText;
public GameObject dialogBox;
public GameObject npcImage;
private BoxCollider2D boxCollider;
public DialogManager dialogManager;
public bool playerInRange;
private bool dialogOpen;

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
                if (!GameObject.Find("DialogBox")) 
            {
                dialogBox.SetActive(true);
                //dialogText.text = dialog;
                //FindObjectOfType<DialogManager>().StartDialogue(dialogue);
                dialogManager.StartDialogue(dialogue);
            }     
            }
        }   
   }

