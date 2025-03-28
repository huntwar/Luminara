using System.Collections;
using UnityEngine;

public class KeyDetection : MonoBehaviour
{
    public string requiredTag = "SesameOpen";
    public float followSpeed = 5f;

    public GameObject key;
    private GameObject player;
    private bool canPickUp = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("✅ Key picked up!");
            checkKeyTag();

        }


    }

    private void checkKeyTag()
    {
        if (key.tag == requiredTag)
        {
            Debug.Log("?? Key is correct.");
            StartCoroutine(FollowPlayer());
        }
        else
        {
            Debug.Log("?? Key is incorrect. Destroying...");
            Destroy(key);
        }
    }

    // Detects when player enters key's trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("🔥 Entered trigger with: " + other.gameObject.name);

        canPickUp = true;
        Debug.Log("🔑 Key detected! Press E to pick up.");
    }

    // Detects when player leaves key area
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("❌ Left trigger of: " + other.gameObject.name);

        canPickUp = false;
    }

    private IEnumerator FollowPlayer()
    {
        while (key != null)
        {
            key.transform.position = Vector3.MoveTowards(key.transform.position, player.transform.position, followSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
