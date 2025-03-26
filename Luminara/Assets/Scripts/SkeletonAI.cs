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
        targetPosition = startPosition + Vector2.right * patrolRange;
    }

    void Update()
    {
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
                Destroy(player);
                AttackPlayer();
            }
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        canAttack = false;

    }

    void ResetAttack()
    {
        canAttack = true;
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
}
