using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject settings;
    public GameObject gameplay;

    void Start()
    {
        // Disable the gameplay GameObject when the game starts
        gameplay.SetActive(false);
        settings.SetActive(false);
    }

    public void StartGame()
    {
        Debug.Log("Start Game button clicked");
        // Disable the start screen UI and enable the gameplay
        startScreen.SetActive(false);
        gameplay.SetActive(true);
    }

    public void OpenSettings()
    {
        Debug.Log("Open Settings button clicked");
        // Disable the start screen UI and enable the settings UI
        startScreen.SetActive(false);
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        Debug.Log("Close Settings button clicked");
        // Disable the settings UI and enable the start screen UI
        settings.SetActive(false);
        startScreen.SetActive(true);
    }
}
