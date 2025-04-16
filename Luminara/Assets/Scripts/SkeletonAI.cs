using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    public float attackRange = 1f;  // Attack distance

    private Transform playerTransform;
    private GameObject player;
    private bool canAttack = true;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerTransform == null) return;


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


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            Debug.Log("Skeleton Attacked the Player!");
            AttackPlayer();
        }
    }

}