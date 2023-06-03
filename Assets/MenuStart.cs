using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button NewGameButton;
    [SerializeField] private Button LoadGameButton;

    private void Start()
    {
        if (!DataPeristenceManager.instance.HasGameData())
        {
            LoadGameButton.interactable = false;
        }
    }

    public void OnNewGameClick()
    {
        DisableMenuButton();

        Debug.Log("new game");

        DataPeristenceManager.instance.NewGame();

        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void OnLoadGameCLick()
    {
        DisableMenuButton();

        SceneManager.LoadSceneAsync("SampleScene");
        Debug.Log("load game");
    }

    private void DisableMenuButton()
    {
        NewGameButton.interactable = false;
        LoadGameButton.interactable = false;
    }
}
