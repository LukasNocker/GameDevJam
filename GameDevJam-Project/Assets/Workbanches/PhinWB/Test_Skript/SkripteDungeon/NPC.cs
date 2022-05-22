using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{ 
public ContactFilter2D filter;
private BoxCollider2D boxCollider;
private Collider2D[] hits = new Collider2D[10];
private float lastInteraction;
private float cooldownNpc = 2.0f;


    protected virtual void Start()
{
    boxCollider = GetComponent<BoxCollider2D>();
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

        //teh array is not cleaned up, so we do it ourself
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
                GameManager.instance.ShowText("Hey! My Name is Avery. Who are you?", 15, Color.white, transform.position, Vector3.up * 20, 3.0f);

            }   
        }
    }
}
