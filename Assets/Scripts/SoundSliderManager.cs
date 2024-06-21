using UnityEngine;
using UnityEngine.UI;

public class SoundSliderManager : MonoBehaviour
{
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Slider MasterSlider;

    private void Start()
    {
        // Set initial values if needed
        SFXSlider.value = SoundManager.GetSFXVolume();
        MusicSlider.value = SoundManager.GetMusicVolume();
        MasterSlider.value = 1f;

        // Add listeners to sliders
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
        MusicSlider.onValueChanged.AddListener(SetMusicVolume);
        MasterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    public void SetSFXVolume(float volume)
    {
        SoundManager.SetSFXVolume(volume);
    }

    public void SetMusicVolume(float volume)
    {
        SoundManager.SetMusicVolume(volume);
    }

    public void SetMasterVolume(float volume)
    {
        SoundManager.SetMasterVolume(volume);
    }
}
