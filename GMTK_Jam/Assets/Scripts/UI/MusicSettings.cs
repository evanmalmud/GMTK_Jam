﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider EffectSlider;
    public Toggle SoundToggle;
        
    // Start is called before the first frame update

    public void LoadSettings()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        Mixer.SetFloat("Music", musicVolume);
        MusicSlider.value = musicVolume;

        float effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0f);
        Mixer.SetFloat("Effects", effectsVolume);
        EffectSlider.value = effectsVolume;

        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        Mixer.SetFloat("Master", masterVolume);
        MasterSlider.value = masterVolume;

        int soundOff = PlayerPrefs.GetInt("SoundOff", 0);
        SoundToggle.isOn = soundOff == 1;
    }

    public void MusicSliderUpdate()
    {
        Mixer.SetFloat("Music", MusicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }

    public void EffectSliderUpdate()
    {
        Mixer.SetFloat("Effects", EffectSlider.value);
        PlayerPrefs.SetFloat("EffectsVolume", EffectSlider.value);
    }

    public void MasterSliderUpdate()
    {
        Mixer.SetFloat("Master", MasterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
    }

    public void OnSoundToggleChange()
    {
        if (SoundToggle.isOn)
        {
            Mixer.SetFloat("Master", -80);
        } else
        {
            Mixer.SetFloat("Master", MasterSlider.value);
        }
        
        PlayerPrefs.SetInt("SoundOff", SoundToggle.isOn ? 1 : 0);
    }
}
