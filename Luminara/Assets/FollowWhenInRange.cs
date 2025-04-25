using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FollowWhenInRange : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    [SerializeField] private Animator animator;

    [Header("Settings")]
    public float followRange = 5f; // Distance at which skeleton starts following

    private AIDestinationSetter destinationSetter;
    private AILerp aiLerp;

    private void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiLerp = GetComponent<AILerp>();

        if (destinationSetter != null)
            destinationSetter.target = null; // Start with no target

        if (aiLerp != null)
            aiLerp.enabled = false;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followRange)
        {
            // Activate pathfinding
            if (destinationSetter != null && destinationSetter.target != player)
                destinationSetter.target = player;

            if (aiLerp != null && !aiLerp.enabled)
                aiLerp.enabled = true;
        }
        else
        {
            // Stop pathfinding
            if (destinationSetter != null && destinationSetter.target != null)
                destinationSetter.target = null;

            if (aiLerp != null && aiLerp.enabled)
                aiLerp.enabled = false;
        }

        // Set walk animation based on movement
        if (animator != null && aiLerp != null)
        {
            //bool isMoving = aiLerp.velocity.magnitude > 0.00f;
            animator.SetBool("IsWalking", aiLerp.enabled);
        }
    }
}
