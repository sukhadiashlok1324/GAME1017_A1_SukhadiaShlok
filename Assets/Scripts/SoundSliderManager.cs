using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SoundSliderManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;
    public Slider masterSlider;

    private float musicVolume = 1f;
    private float soundVolume = 1f;
    private float masterVolume = 1f;

    private List<AudioSource> musicSources = new List<AudioSource>();
    private List<AudioSource> soundSources = new List<AudioSource>();

    void Start()
    {
        
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundSlider.onValueChanged.AddListener(SetSoundVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);

       
        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;
        masterSlider.value = masterVolume;

        
        AudioSource musicSource = gameObject.AddComponent<AudioSource>();
        musicSources.Add(musicSource);
    }

    void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        UpdateVolumes();
    }

    void SetSoundVolume(float volume)
    {
        soundVolume = volume;
        UpdateVolumes();
    }

    void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        UpdateVolumes();
    }

    void UpdateVolumes()
    {
        foreach (var musicSource in musicSources)
        {
            musicSource.volume = musicVolume * masterVolume;
        }
    }
}
