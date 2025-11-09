using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    [SerializeField]AudioSource musicAudioSource;
    [SerializeField]AudioSource sfxAudioSource;
    float musicVolume;
    float sfxVolume;
    void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f); // valor per defecte 0.5
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        ApplyVolumeSettings(); // Aplica el volum als àudios
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMusicSliderChanged(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
        musicAudioSource.volume = value;
    }

    public void OnSFXSliderChanged(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
        sfxAudioSource.volume = value;
    }

    void ApplyVolumeSettings()
    {
        musicAudioSource.volume = musicVolume;
        sfxAudioSource.volume = sfxVolume;  
    }
}
