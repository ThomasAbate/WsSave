using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int deathCount;
    public Vector3 PlayerPos;
    public ZerializableDictionary<string, bool> coinsCollected;
    public float Volume;
    public GameData()
    {
        this.deathCount = 0;
        this.Volume = 0;
        PlayerPos = Vector3.zero;
        coinsCollected = new ZerializableDictionary<string, bool>();
    }
}
