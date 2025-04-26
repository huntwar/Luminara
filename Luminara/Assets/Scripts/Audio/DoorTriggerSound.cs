using UnityEngine;
using Luminara.SoundManager;

public class DoorTriggerSound : MonoBehaviour
{
    [Header("Door Sounds")]
    public SoundType openSound;
    public SoundType closeSound;

    private bool isOpenNext = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayDoorSound();
        }
    }

    private void PlayDoorSound()
    {
        if (isOpenNext)
        {
            SoundManager.PlaySound(SoundType.Door);
        }
        else
        {
            SoundManager.PlaySound(SoundType.Door);
        }

        isOpenNext = !isOpenNext;
    }
}