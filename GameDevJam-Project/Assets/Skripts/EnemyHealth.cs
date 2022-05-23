using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        //play hurt animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // play die animation
        //dieable enemy
        Debug.Log("enemy died");

        Destroy(transform.root.gameObject);
    }
}
