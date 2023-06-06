using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour, IDataPeristence
{
    public Slider volumeSlider;
    public AudioSource Audio;
    public float Volume;

    public void LoaData(GameData data)
    {
         this.Volume = data.Son;
    }

    public void SaveData(ref GameData data)
    {
        data.Son = this.Volume;
    }

    public void UpdateVolume() 
    {
        Audio.volume = volumeSlider.value;
        Volume = volumeSlider.value;
    }
}
