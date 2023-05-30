using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class DataPeristenceManager : MonoBehaviour
{
    [Header("Fait toi plaisir")]
    [SerializeField] private string fileName;
    
    private GameData gameData; 
    private List<IDataPeristence> dataPersistenceObjects;
    private FileDataHandler DataHandler;
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
        this.DataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = DataHandler.Load();
        
        if (this.gameData == null) 
        {
            Debug.Log("Ta pas de Save");
            NewGame();
        }

        foreach (IDataPeristence dataPeristenceObj in dataPersistenceObjects)
        {
            dataPeristenceObj.LoaData(gameData);
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

        DataHandler.Save(gameData);

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }



    private List<IDataPeristence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPeristence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPeristence>();
        
        return new List<IDataPeristence>(dataPersistenceObjects);
    }

}
