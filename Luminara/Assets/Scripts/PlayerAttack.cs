using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 3;
    public float attackRange = 1f;
    public float attackCooldown = 1f;
    private bool canAttack = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack) // Press SPACE to attack
        {
            Attack();
        }
    }

    void Attack()
    {
        canAttack = false;
        Debug.Log("Player attacks!");

        // Check if skeleton is in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<HealthSystem>().TakeDamage(attackDamage);
            }
        }

        Invoke(nameof(ResetAttack), attackCooldown); // Cooldown before next attack
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    void OnDrawGizmosSelected() // Show attack range in Scene View
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
