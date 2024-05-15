using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject gameplay;
    public GameObject deathScreen;
    public GameResetting resetGameScript;
    
    public GameObject playerObject; // Reference to the player GameObject
    private PlayerHealth playerHealth; // Reference to the PlayerHealth script
    
    public GameObject music; // Reference to the Music GameObject
    private BGMManager bgmManager; // Reference to the BGMManager script

    void Start()
    {
        // Ensure all screen objects are correctly initialized
        mainMenu.SetActive(true);
        gameplay.SetActive(false);
        settings.SetActive(false);
        deathScreen.SetActive(false);

        // Get a reference to the PlayerHealth script
        if (playerObject != null)
        {
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogWarning("Player GameObject is not assigned to the ScreenManager script.");
        }

        // Get a reference to the BGMManager script
        if (music != null)
        {
            bgmManager = music.GetComponent<BGMManager>();
        }
        else
        {
            Debug.LogWarning("Music GameObject is not assigned to the ScreenManager.");
        }

        // Ensure the main menu BGM is playing initially
        if (bgmManager != null)
        {
            bgmManager.PlayMainMenuBGM();
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

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
    }

    public void StartGame()
    {
        if (resetGameScript != null)
        {
            resetGameScript.ResetGame();
        }
        else
        {
            Debug.LogWarning("ResetGame script is not assigned to the ScreenManager.");
        }

        Debug.Log("Start Game button clicked");
        // Switches to Gameplay
        mainMenu.SetActive(false);
        gameplay.SetActive(true);
        settings.SetActive(false);
        deathScreen.SetActive(false);

        ResumeGame(); // Ensure the game is running

        // Switch BGM to gameplay
        if (bgmManager != null)
        {
            bgmManager.PlayGameplayBGM();
        }
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked");
        PauseGame(); // Pause the game when opening settings
        // Switches to Settings Menu
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        Debug.Log("Close Settings button clicked");
        settings.SetActive(false);
        ResumeGame(); // Resume the game when closing settings
    }

    public void ReturnMenu()
    {
        if (resetGameScript != null)
        {
            resetGameScript.ResetGame();
        }
        else
        {
            Debug.LogWarning("ResetGame script is not assigned to the ScreenManager.");
        }

        Debug.Log("Start Menu button clicked");
        // Switches to Start Game Menu
        mainMenu.SetActive(true);
        gameplay.SetActive(false);
        settings.SetActive(false);
        deathScreen.SetActive(false);

        ResumeGame(); // Ensure the game is running

        // Switch BGM to main menu
        if (bgmManager != null)
        {
            bgmManager.PlayMainMenuBGM();
        }
    }

    // Function to activate death screen
    void ShowDeathScreen()
    {
        Debug.Log("Player Died");
        gameplay.SetActive(false);
        deathScreen.SetActive(true);

        resetGameScript.ResetGame();

        // Switch BGM to main menu
        if (bgmManager != null)
        {
            bgmManager.StopBGM();
        }
    }
}

