using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
       
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject); // Removes the object when dead
    }
}
