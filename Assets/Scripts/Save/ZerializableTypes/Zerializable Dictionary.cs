using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class ZerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> Coins = new List<TKey>();
    [SerializeField] private List<TValue> value = new List<TValue>();
    public void OnBeforeSerialize()
    {
        Coins.Clear();
        value.Clear();
        foreach(KeyValuePair<TKey, TValue> pair in this)
        {
            Coins.Add(pair.Key);
            value.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();
        
        if(Coins.Count != value.Count)
        {
            Debug.LogError("j'ai pas compris à quoi cers se truc mais si je le vois c'est mal");
        }

        for (int i = 0; i < Coins.Count; i++)
        {
            this.Add(Coins[i], value[i]);
        }
    }
}
