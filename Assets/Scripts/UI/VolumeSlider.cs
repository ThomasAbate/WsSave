using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour, IDataPeristence
{
    public Slider volumeSlider;
    public AudioSource audio;

    public void LoaData(GameData data)
    {
         this.volumeSlider.value = data.Volume;
    }

    public void SaveData(ref GameData data)
    {
        data.Volume = this.volumeSlider.value;
    }

    public void Update() 
    {
        audio.volume = volumeSlider.value;
    }
}
