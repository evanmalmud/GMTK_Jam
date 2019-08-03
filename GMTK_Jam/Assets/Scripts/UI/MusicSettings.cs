using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider MusicSlider;
    public Slider EffectSlider;
    public Toggle SoundToggle;

    public GameObject Background;
        
    // Start is called before the first frame update
    void Start()
    {
        Mixer.GetFloat("Music", out var value);
        MusicSlider.value = value;
        Mixer.GetFloat("Effects", out value);
        EffectSlider.value = value;
        
        Background.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Background.SetActive(!Background.activeSelf);
        }
    }

    public void MusicSliderUpdate()
    {
        Debug.Log(MusicSlider.value);
        Mixer.SetFloat("Music", MusicSlider.value);
    }

    public void EffectSliderUpdate()
    {
        Debug.Log(EffectSlider.value);
        Mixer.SetFloat("Effects", EffectSlider.value);
    }

    public void OnSoundToggleChange()
    {
        Debug.Log(SoundToggle.isOn);
        if (SoundToggle.isOn)
        {
            Mixer.SetFloat("Master", -80);
        } else
        {
            Mixer.SetFloat("Master", 0);
        }
    }
}
