using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class ZerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> value = new List<TValue>();
    public void OnBeforeSerialize()
    {
        keys.Clear();
        value.Clear();
        foreach(KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            value.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();
        
        if(keys.Count != value.Count)
        {
            Debug.LogError("j'ai pas compris à quoi cers se truc mais si je le vois c'est mal");
        }

        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], value[i]);
        }
    }
}
