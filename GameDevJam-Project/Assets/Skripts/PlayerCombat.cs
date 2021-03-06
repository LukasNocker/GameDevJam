using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public int attackDamage = 4;

    public ParticleSystem  blood;

    private void Update()
    {
        if(!PauseMenu.isPaused){
            if (!GameObject.Find("DialogBox"))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                  Attack();
                }
            }
        }

        blood.transform.position = attackPoint.position;
    }

   void Attack()
   {
        // play attack animation
        Debug.Log("attacked");

        // detect enemys in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            blood.Play();
            HealthSystem healthSystem =  enemy.GetComponent<HealthSystem>();
            healthSystem.Damage(1);

            //enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
   }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
