using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IDataPeristence
{

    [SerializeField] private string id;

    [ContextMenu("Voila ton ID")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private SpriteRenderer visual;
    private bool collected = false;

    private void Awake() 
    {
        visual = this.GetComponentInChildren<SpriteRenderer>();
    }

    public void LoaData(GameData data)
    {
        data.coinsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.coinsCollected.ContainsKey(id)) 
        { 
            data.coinsCollected.Remove(id);
        }
        data.coinsCollected.Add(id, collected);
    }

    private void OnTriggerEnter2D() 
    {
        if (!collected) 
        {
            CollectCoin();
        }
    }

    private void CollectCoin() 
    {
        collected = true;
        visual.gameObject.SetActive(false);
        GameEventsManager.instance.CoinCollected();
    }

}
