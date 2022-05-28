using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollectable : Collectable
{
    public int soulsAmount = 1;
    private void OnTriggerEnter2D(Collider2D collision) {
         if (collision.gameObject.CompareTag("Companion"))
         {
          Debug.Log("+" + soulsAmount + " collected by Companion");
          GameObject player = GameObject.FindWithTag("Player");
          GameManager manager = player.GetComponent<GameManager>();
          if (manager)
            {
                manager.PickupSoul();
            }
            Destroy(this.gameObject);
         }
    }

}
