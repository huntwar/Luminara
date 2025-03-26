using UnityEngine;

public class NpcAI : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;  // Distance at which the skeleton detects the player
    public float loseRangeMultiplier = 1.5f; // How far before it stops chasing
    public float patrolRange = 3f; // Distance the skeleton moves left and right
    private Transform player;
    private bool chasing = false;
    private Vector2 startPosition;
    private Vector2 targetPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        targetPosition = startPosition + Vector2.right * patrolRange; // Start patrolling to the right
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

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
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.2f)
        {
            // Switch target between left and right
            targetPosition = targetPosition == (startPosition + Vector2.right * patrolRange)
                ? startPosition + Vector2.left * patrolRange
                : startPosition + Vector2.right * patrolRange;
        }
    }
}
