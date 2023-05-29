using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("+ de 1 instance");
        }
        instance = this;
    }

    public event Action onPlayerDeath;
    public void PlayerDeath() 
    {
        if (onPlayerDeath != null) 
        {
            onPlayerDeath();
        }
    }

    public event Action onCoinCollected;
    public void CoinCollected() 
    {
        if (onCoinCollected != null) 
        {
            onCoinCollected();
        }
    }
}
