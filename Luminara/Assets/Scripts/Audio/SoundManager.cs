using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Luminara.SoundManager
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private SoundsSO SO;
        private static SoundManager instance = null;
        private AudioSource audioSource;
        private AudioSource musicSource;

private void Awake()
{
    if (instance != null && instance != this)
    {
        Destroy(gameObject);
        return;
    }

    instance = this;
    DontDestroyOnLoad(gameObject);

    AudioSource[] sources = GetComponents<AudioSource>();
    if (sources.Length < 2)
    {
        musicSource = gameObject.AddComponent<AudioSource>();
    }
    else
    {
        musicSource = sources[1]; 
    }

    audioSource = GetComponent<AudioSource>();
}

    public static SoundList GetSound(SoundType type)
    {
        return instance.SO.sounds[(int)type];
    }

        public static void PlaySound(SoundType sound, AudioSource source = null, float volume = 1)
        {
            SoundList soundList = instance.SO.sounds[(int)sound];
            AudioClip[] clips = soundList.sounds;
            AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];

            if(source)
            {
                source.outputAudioMixerGroup = soundList.mixer;
                source.clip = randomClip;
                source.volume = volume * soundList.volume;
                source.Play();
            }
            else
            {
                instance.audioSource.outputAudioMixerGroup = soundList.mixer;
                instance.audioSource.PlayOneShot(randomClip, volume * soundList.volume);
            }
        }

        public static void PlayMusic(SoundType musicType, float volume = 1f)
    {
        SoundList soundList = instance.SO.sounds[(int)musicType];
        AudioClip musicClip = soundList.sounds[0];

        instance.musicSource.clip = musicClip;
        instance.musicSource.loop = true;
        instance.musicSource.volume = volume * soundList.volume;
        instance.musicSource.outputAudioMixerGroup = soundList.mixer;
        instance.musicSource.Play();
    }
    }
    

    [Serializable]
    public struct SoundList
    {
        [HideInInspector] public string name;
        [Range(0, 1)] public float volume;
        public AudioMixerGroup mixer;
        public AudioClip[] sounds;
    }
}