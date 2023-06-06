using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource Audio;
    public float Volume;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
            Audio.volume = volumeSlider.value;
        }
    }
    public void UpdateVolume() 
    {
        Audio.volume = volumeSlider.value;
        Volume = volumeSlider.value;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
