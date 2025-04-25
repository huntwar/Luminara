using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;
    public float loseRangeMultiplier = 1.5f;
    public float patrolRange = 3f;
    public float attackRange = 1f;  // Attack distance

    private Transform playerTransform;
    private GameObject player;
    private bool chasing = false;
    private bool canAttack = true;
    private Vector2 startPosition;
    private Vector2 targetPosition;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        
    }

    void Update()
    {
        if (playerTransform == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < detectionRange)
        {
            chasing = true;
        }
        else if (distanceToPlayer > detectionRange * loseRangeMultiplier)
        {
            chasing = false;
        }

            Patrol();
    }


    void AttackPlayer()
    {

        if (player == null) return;

        canAttack = false;
        RestartGame();
    }

    void RestartGame()
    {
        Debug.Log("Game Over! Restarting...");
        // Destroy the player
        Destroy(player);
        // Wait for a short delay before restarting
        Invoke("ReloadScene", 1.5f);
    }

    void ReloadScene()
    {
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

   void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.2f)
        {
            targetPosition = targetPosition == (startPosition + Vector2.right * patrolRange)
                ? startPosition + Vector2.left * patrolRange
                : startPosition + Vector2.right * patrolRange;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            Debug.Log("Skeleton Attacked the Player!");
            AttackPlayer();
        }
    }

}