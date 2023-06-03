using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;

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
            Debug.LogError("Attention, A pu");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.DataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnScenneLoaded est appelé");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded est appelé");
        SaveGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
        Debug.Log("oui");
    }
    public void LoadGame()
    {
        this.gameData = DataHandler.Load();
        
        if (this.gameData == null) 
        {
            Debug.Log("Ta pas de Save");
            return;
        }

        foreach (IDataPeristence dataPeristenceObj in dataPersistenceObjects)
        {
            dataPeristenceObj.LoaData(gameData);
        }
        
        Debug.Log(gameData.deathCount + " Mort L");

    }
    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.LogWarning("No data, pas de jeu");
        }
        
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

    public bool HasGameData()
    {
        return gameData != null;
    }

}
