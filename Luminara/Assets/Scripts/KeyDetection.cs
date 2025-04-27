using Luminara.SoundManager;
using UnityEngine;

public class KeyDetection : MonoBehaviour
{
    public float followSpeed = 5f;
    public bool isGoldenKey;
    public GameObject key;
    private GameObject player;
    private bool canPickUp = false;
    private bool shouldFollow = false;

    private KeySound keySound;
    private string pickUpKey;

    private void Start()
    {
        pickUpKey = GameData.Instance.myPickUpKey.text;
        player = GameObject.FindGameObjectWithTag("Player");

        keySound = GetComponentInChildren<KeySound>();
    }

    private void Update()
    {

        KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), pickUpKey);
        if (canPickUp && Input.GetKeyDown(pickUpKey))
        {
            if (isGoldenKey)
            {
                shouldFollow = true; // Start following
            }
            else
            {
                Destroy(key);
            }

            SoundManager.PlaySound(SoundType.KeyPickup);

            if (keySound != null)
            {
                keySound.StopKeySound();
            }
        }

        if (shouldFollow)
        {
            FollowPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"🔑 Key detected! Press {pickUpKey} to pick up.");
            canPickUp = true;
        }
    }

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