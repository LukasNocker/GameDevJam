using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollectable : Collectable
{
    public int soulsAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        Debug.Log("+" + soulsAmount + " Souls collected");

        //Test if the Player has a manager attached, 
        GameManager manager = collision.GetComponent<GameManager>();
         if (manager)
            {
                manager.PickupSoul();
            }
        Destroy(this.gameObject);
    }
    // {
    //     if (!collected)
    //     {
    //         collected = true;
    //         Debug.Log("+" + soulsAmount + " Souls collected");
    //         GameManager manager = GetComponent<GameManager>();
    //         Destroy(this.gameObject);
            
    //         if (manager)
    //         {
    //             manager.PickupSoul();
    //         }
    //         //Verbindung zum Game Manager missing to really store the Souls
    //     }
    // }
}
