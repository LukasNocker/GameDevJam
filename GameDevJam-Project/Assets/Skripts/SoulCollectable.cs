using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollectable : Collectable
{
    public int soulsAmount = 1;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            Debug.Log("+" + soulsAmount + " Souls collected");
            Destroy(this.gameObject);
            //Verbindung zum Game Manager missing to really store the Souls
        }
    }
}
