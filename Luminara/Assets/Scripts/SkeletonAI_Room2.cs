using UnityEngine;
using UnityEngine.UIElements;

public class SkeletonAI_Room2 : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;
    public float loseRangeMultiplier = 1.5f;
    public float patrolRange = 3f;
    public float attackRange = 1f;  // Attack distance

    private Transform playerTransform;
    private GameObject player;
    public GameObject Key1_Room2_ChandelierTask;
    public bool isActivated;
    private bool chasing = false;
    private bool canAttack = true;
    private Vector2 startPosition;
    private Vector2 targetPosition;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        targetPosition = startPosition + Vector2.right * patrolRange;
    }

    void Update()
        {
        if (Key1_Room2_ChandelierTask == null || !Key1_Room2_ChandelierTask.activeInHierarchy)
            return; // Skip everything if the chandelier isn't active

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

            if (chasing)
            {
                if (distanceToPlayer > attackRange)
                {
                    ChasePlayer();
                }
                else if (canAttack)
                {
                    Debug.Log("Skeleton Attack");
                    AttackPlayer();
                }
            }
            else
            {
                Patrol();
            }
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

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
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