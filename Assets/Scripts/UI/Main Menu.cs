using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

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
        DataPeristenceManager.instance.OnApllicationQuit();
    }
}
