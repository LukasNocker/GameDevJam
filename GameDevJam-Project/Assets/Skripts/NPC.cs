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
public ContactFilter2D filter;
private BoxCollider2D boxCollider;
private Collider2D[] hits = new Collider2D[10];
private float lastInteraction;
private float cooldownNpc = 2.0f;
public bool playerInRange;




    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        dialogBox.SetActive(false);
    }

protected virtual void Update()
{
    // Collison work
    boxCollider.OverlapCollider(filter, hits);
    for (int i = 0; i < hits.Length; i++)
    {
        if (hits[i] == null)
            continue;


        OnCollide(hits[i]);

        //the array is not cleaned up, so we do it ourself
        hits[i] = null;
    }
}
    protected virtual void OnCollide(Collider2D coll)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time - lastInteraction > cooldownNpc)
            {
                lastInteraction = Time.time;
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);

                }
                else
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                }
                

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
