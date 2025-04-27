using UnityEngine;
using Luminara.SoundManager;

public class ChandelierSound : MonoBehaviour
{
    public SoundType chandelierSound;
    public float maxVolume = 1f;
    public float detectionRange = 5f;

    private AudioSource soundSource;
    private Transform playerTransform;
    private bool isPlayerNear = false;

    private void Start()
    {
        soundSource = gameObject.AddComponent<AudioSource>();
        soundSource.loop = true;

        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found in the scene! Make sure the player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (!isPlayerNear || playerTransform == null)
            return;

        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance > detectionRange)
        {
            soundSource.volume = 0f;
            return;
        }

        float normalizedDistance = 1 - (distance / detectionRange);
        soundSource.volume = maxVolume * normalizedDistance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered near the chandelier!");
            SoundList sound = SoundManager.GetSound(SoundType.Fire);
            soundSource.clip = sound.sounds[Random.Range(0, sound.sounds.Length)];
            soundSource.outputAudioMixerGroup = sound.mixer;
            soundSource.Play();
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player moved away from the chandelier!");
            isPlayerNear = false;
            soundSource.Stop();
        }
    }
}