using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPeristenceManager : MonoBehaviour
{
    private GameData gameData; 
    private List<IDataPeristence> dataPersistenceObjects;
    public static DataPeristenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Attention");
        }
        instance = this; 
    }

    public void Start()
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        if (this.gameData == null) 
        {
            Debug.Log("Ta pas de Save");
            NewGame();
        }

        foreach (IDataPeristence dataPeristenceObj in dataPersistenceObjects)
        {
            dataPeristenceObj.LoaaData(gameData);
        }
        
        Debug.Log(gameData.deathCount + " Mort L");

    }
    public void SaveGame()
    {
        foreach (IDataPeristence dataPeristenceObj in dataPersistenceObjects)
        {
            dataPeristenceObj.SaveData(ref gameData);
        }
        
        Debug.Log(gameData.deathCount + " Mort S");

    }

    public void OnApllicationQuit()
    {
        SaveGame();
    }

    private List<IDataPeristence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPeristence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPeristence>();
        
        return new List<IDataPeristence>(dataPersistenceObjects);
    }

}
