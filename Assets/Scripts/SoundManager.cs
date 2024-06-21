using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum SoundType
    {
        SOUND_SFX,
        SOUND_MUSIC,
        LENGTH
    }

    private static Dictionary<string, AudioClip> sfxDictionary = new Dictionary<string, AudioClip>();
    private static Dictionary<string, AudioClip> musicDictionary = new Dictionary<string, AudioClip>();
    private static AudioSource sfxSource;
    private static AudioSource musicSource;
    private static float masterVolume = 1f;

    static SoundManager() // Static constructor. Gets called the first time the class is accessed.
    {
        Initialize();
    }

    private static void Initialize()
    {
        // Create a new GameObject to hold the AudioSource
        GameObject soundManagerObject = new GameObject("SoundManager");

        // Create and attach AudioSource to the Gameobject.
        sfxSource = soundManagerObject.AddComponent<AudioSource>();
        sfxSource.volume = 0.75f;
        musicSource = soundManagerObject.AddComponent<AudioSource>();
        musicSource.volume = 0.25f;
        musicSource.loop = true;
    }

    public static void AddSound(string soundKey, AudioClip audioClip, SoundType soundType)
    {
        Debug.Log("Adding sound SFX" + soundKey);
        if (soundType == SoundType.SOUND_SFX && !sfxDictionary.ContainsKey(soundKey))
        {
            sfxDictionary.Add(soundKey, audioClip);
        }
        else if (soundType == SoundType.SOUND_MUSIC && !musicDictionary.ContainsKey(soundKey))
        {
            musicDictionary.Add(soundKey, audioClip);
        }
        else
        {
            Debug.LogError("Invalid key or key exist in target dictionary!");
        }
    }

    public static void PlaySound(string soundKey)
    {
        sfxSource.PlayOneShot(sfxDictionary[soundKey]);
    }

    public static void PlayMusic(string soundKey)
    {
        musicSource.Stop();
        musicSource.clip = musicDictionary[soundKey]; // Load a clip into the music source.
        musicSource.Play();
    }

    public static void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume * masterVolume;
    }

    public static void SetMusicVolume(float volume)
    {
        musicSource.volume = volume * masterVolume;
    }

    public static void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        SetSFXVolume(sfxSource.volume);
        SetMusicVolume(musicSource.volume);
    }

    public static float GetSFXVolume()
    {
        return sfxSource.volume / masterVolume;
    }

    public static float GetMusicVolume()
    {
        return musicSource.volume / masterVolume;
    }
}
