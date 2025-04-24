using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChandelierInteraction : MonoBehaviour
{
    public Light2D chandelierLight; // Assign this in Inspector
    public GameObject Key1_Room2_ChandelierTask; // Assign this only on the special chandelier
    public KeyCode actionKey = KeyCode.E;

    private bool isPlayerNearby = false;
    public bool isActivated = false;

    void Start()
    {
        // Deactivate light only for the one chandelier you want
        // This is optional if you're only setting it manually in Inspector
        if (Key1_Room2_ChandelierTask != null)
        {
            Key1_Room2_ChandelierTask.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!chandelierLight.enabled && !isActivated)
            {
                chandelierLight.enabled = true;
                Debug.Log("Chandelier light activated!");
                isActivated = true;
                Debug.Log("Key is already activated!");

                if (Key1_Room2_ChandelierTask != null)
                {
                    Key1_Room2_ChandelierTask.SetActive(true);
                    Debug.Log("Special object appeared!");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
