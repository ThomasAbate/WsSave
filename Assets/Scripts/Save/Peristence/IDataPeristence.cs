using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPeristence
{
    void LoaData(GameData data);
    void SaveData(ref GameData data);
}
