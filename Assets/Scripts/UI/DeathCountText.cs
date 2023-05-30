using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCountText : MonoBehaviour, IDataPeristence
{
    private int deathCount = 0;

    private TextMeshProUGUI deathCountText;

    private void Awake() 
    {
        deathCountText = this.GetComponent<TextMeshProUGUI>();
    }

    private void Start() 
    {
        GameEventsManager.instance.onPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy() 
    {
        GameEventsManager.instance.onPlayerDeath -= OnPlayerDeath;
    }

    public void LoaData(GameData data)
    {
        this.deathCount = data.deathCount;
    }

    public void SaveData(ref GameData data)
    {
        data.deathCount = this.deathCount;
    }

    private void OnPlayerDeath() 
    {
        deathCount++;
    }

    private void Update() 
    {
        deathCountText.text = "" + deathCount;
    }
}
