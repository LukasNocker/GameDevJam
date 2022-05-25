using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_dialog : MonoBehaviour
{
    public string dialog;
    public Text dialogText;
    public GameObject dialogBox;
    public GameObject npcImage;
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    private float lastInteraction;
    private float cooldownNpc = 1.0f;
    public bool playerInRange;




    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        dialogBox.SetActive(false);
        playerInRange = false;
    }

    protected virtual void Update()
    {

        //new Collider
        playerInRange = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;


            if (hits[i].tag == "Player" && hits[i].name == "Player")
            {
                playerInRange = true;
            }

            //the array is not cleaned up, so we do it ourself
            hits[i] = null;
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (Input.GetKeyDown(KeyCode.E))
            {

                this.dialogBox.SetActive(true);
                dialogText.text = dialog;

            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                dialogBox.SetActive(false);
            }
    }
    
}
