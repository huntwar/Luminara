using UnityEngine;

public class KeyDetection : MonoBehaviour
{
    public float followSpeed = 5f;
    public bool isGoldenKey;
    public GameObject key;
    private GameObject player;
    private bool canPickUp = false;
    private bool shouldFollow = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            if (isGoldenKey)
            {
                shouldFollow = true; // Start following
            }
            else
            {
                Destroy(key);
            }
        }

        if (shouldFollow)
        {
            FollowPlayer();
        }
    }

    // Detects when player enters key's trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🔑 Key detected! Press E to pick up.");
            canPickUp = true;
        }
    }

    // Detects when player leaves key area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }

    private void FollowPlayer()
    {
        key.transform.position = Vector3.MoveTowards(key.transform.position, player.transform.position, followSpeed * Time.deltaTime);
    }
}
