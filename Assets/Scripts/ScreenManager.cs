using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settings;
    public GameObject gameplay;
    public GameObject deathScreen;
    public GameResetting resetGameScript;
    public GameObject playerObject; // Reference to the player GameObject
    private PlayerHealth playerHealth; // Reference to the PlayerHealth script

    void Start()
    {
        // Disable the gameplay GameObject when the game starts
        startMenu.SetActive(true);
        gameplay.SetActive(false);
        settings.SetActive(false);
        deathScreen.SetActive(false);

        // Get a reference to the PlayerHealth script
        if (playerObject != null) {
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        } else {
            Debug.LogWarning("Player GameObject is not assigned to the ScreenManager script.");
        }
    }

    // Function to check for player death
    void Update()
    {
        if (playerHealth != null && playerHealth.currentHealth <= 0)
        {
            ShowDeathScreen();
        }
    }

    public void StartGame()
    {
        if (resetGameScript != null) {
            resetGameScript.ResetGame();
        } else {
            Debug.LogWarning("ResetGame script is not assigned to the ScreenManager.");
        }
        
        Debug.Log("Start Game button clicked");
        // Switches to Gameplay
        startMenu.SetActive(false);
        gameplay.SetActive(true);
        settings.SetActive(false);
        deathScreen.SetActive(false);
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked");
        // Switches to Settings Menu
        startMenu.SetActive(false);
        gameplay.SetActive(false);
        settings.SetActive(true);
        deathScreen.SetActive(false);
    }

    public void ReturnMenu()
    {
        if (resetGameScript != null) {
            resetGameScript.ResetGame();
        } else {
            Debug.LogWarning("ResetGame script is not assigned to the ScreenManager.");
        }

        Debug.Log("Start Menu button clicked");
        // Switches to Start Game Menu
        startMenu.SetActive(true);
        gameplay.SetActive(false);
        settings.SetActive(false);
        deathScreen.SetActive(false);
    }

    // Function to activate death screen
    void ShowDeathScreen()
    {
        Debug.Log("Player Died");
        startMenu.SetActive(false);
        gameplay.SetActive(false);
        settings.SetActive(false);
        deathScreen.SetActive(true);
        // Optionally, you can pause the game or perform other actions here
    }
}

