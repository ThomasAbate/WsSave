using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCollectedText : MonoBehaviour, IDataPeristence
{
    [SerializeField] private int totalCoins = 0;

    private int coinsCollected = 0;

    private TextMeshProUGUI coinsCollectedText;

    private void Awake() 
    {
        coinsCollectedText = this.GetComponent<TextMeshProUGUI>();
    }

    public void LoaData(GameData data)
    {
        foreach(KeyValuePair<string, bool> pair in data.coinsCollected)
        {
            if(pair.Value)
            {
                coinsCollected++;
            }
        }
    }

    public void SaveData(ref GameData data)
    {

    }

    private void Start() 
    {
        GameEventsManager.instance.onCoinCollected += OnCoinCollected;
    }

    private void OnDestroy() 
    {
        GameEventsManager.instance.onCoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected() 
    {
        coinsCollected++;
    }

    private void Update() 
    {
        coinsCollectedText.text = coinsCollected + " / " + totalCoins;
    }
}
