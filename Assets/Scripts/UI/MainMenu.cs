using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPause;

    public void LoadGameCLick()
    {
        DataPeristenceManager.instance.LoadGame();
    }

    public void SaveGameCLick() 
    {
        DataPeristenceManager.instance.SaveGame();
    }

    public void QuitGameClick()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
