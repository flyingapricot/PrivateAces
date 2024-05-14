using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject gameplay;
    public GameObject pauseMenu;
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
        pauseMenu.SetActive(false);
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
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        deathScreen.SetActive(false);

        // Switch BGM to gameplay
        if (bgmManager != null)
        {
            bgmManager.PlayGameplayBGM();
        }
    }

    public void PauseGame()
    {

    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked");
        // Switches to Settings Menu
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        pauseMenu.SetActive(false);
        settings.SetActive(true);
        deathScreen.SetActive(false);
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
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        deathScreen.SetActive(false);

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
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        deathScreen.SetActive(true);
        // Optionally, you can pause the game or perform other actions here
    }
}

