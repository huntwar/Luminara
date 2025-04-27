using UnityEngine;
using Luminara.SoundManager;

public class KeySound : MonoBehaviour
{
    public SoundType keySound;
    public float maxVolume = 1f;
    public float detectionRange = 20f;

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
            Debug.LogError("Player not found! Make sure your Player has the tag 'Player'.");
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
    normalizedDistance = Mathf.Clamp01(normalizedDistance * normalizedDistance);
    soundSource.volume = maxVolume * normalizedDistance;
}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player approached the key!");

            SoundList sound = SoundManager.GetSound(SoundType.KeyDetection);
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
            Debug.Log("Player moved away from the key!");
            isPlayerNear = false;
            soundSource.Stop();
        }
    }

    public void StopKeySound()
    {
        if (soundSource != null)
            {
                soundSource.Stop();
            }
        isPlayerNear = false;
        gameObject.SetActive(false); // Disattiva completamente la zona suono
    }
}