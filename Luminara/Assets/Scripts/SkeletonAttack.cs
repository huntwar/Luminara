using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SkeletonAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator skeletonAnimator;

    private Transform playerTransform;
    private GameObject player;
    private bool canAttack = false;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        player = GameObject.FindGameObjectWithTag("Player");

        if (skeletonAnimator == null)
            Debug.LogWarning("Animator not assigned on " + gameObject.name);
    }

    void Update()
    {
        // Currently empty, but can be used for cooldown or range logic
    }

    void AttackPlayer()
    {
        if (player == null) return;

        if (canAttack)
        {
            Debug.Log($"can attack: {canAttack}");
            skeletonAnimator.SetTrigger("Attack");
        }
        canAttack = false;

        RestartGame();


    }

    void RestartGame()
    {
        Debug.Log("Game Over! Restarting...");
        Destroy(player);
        Invoke(nameof(ReloadScene), 3f);

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = true;
            AttackPlayer();
        }
    }
}