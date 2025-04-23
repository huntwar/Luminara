using UnityEngine;
using Pathfinding;

public class FollowWhenInRange : MonoBehaviour
{
    public Transform player;
    public float followRange = 3f; // Distance at which skeleton starts following
    private AIDestinationSetter destinationSetter;
    private AILerp aiLerp;

    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiLerp = GetComponent<AILerp>();

        if (destinationSetter != null)
            destinationSetter.target = null; // Start with no target
    }

    void Update()
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
    }
}
