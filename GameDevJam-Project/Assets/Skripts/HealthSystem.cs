
using UnityEngine;

public class HealthSystem :  MonoBehaviour
{
    
    public float hitPoints;
    public float maxHitpoint;

    public GameObject SoulCollectable;

    public HealthSystem (float maxHitpoint) {
        this.maxHitpoint = maxHitpoint;
        hitPoints = maxHitpoint;
    }
    public float GetHealth() {
        return hitPoints;
    }

    public void Damage(float damageAmount) {
        hitPoints -= damageAmount;
        if (GameManager.instance)
        {
            GameManager.instance.Health();
        }
        if (hitPoints < 0 ) 
        {hitPoints = 0;
        Destroy(gameObject);
        // this can be handled in a different class:
        if (gameObject.CompareTag("Enemy"))
        {
            Instantiate(SoulCollectable, transform.position, transform.rotation);
            
        }
        }
    }
    public void Heal(float healAmount) {
        hitPoints += healAmount;
        if (hitPoints > maxHitpoint) hitPoints = maxHitpoint;
    }
}
