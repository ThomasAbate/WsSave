using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPause;
    public void NewGameCLick()
    {
        DataPeristenceManager.instance.NewGame();
    }

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
        Application.Quit();
    }
}
