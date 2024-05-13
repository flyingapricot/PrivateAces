using UnityEngine;

public class GameResetting : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player GameObject
    private PlayerHealth playerHealth;
    public GameObject exampleEnemyPrefab; // Example enemy prefab to destroy

    void Start()
    {
        // Get a reference to the PlayerHealth script
        if (playerObject != null) {
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        } else {
            Debug.LogWarning("Player GameObject is not assigned to the ScreenManager script.");
        }

    }

    // Reset the player to the starting position (0, 0, 0) and full health
    void ResetPlayer()
    {
        playerObject.transform.position = Vector3.zero; // Reset position
        playerHealth.currentHealth = playerHealth.maxHealth;
    }

    public void ResetGame()
    {
        // Reset Player
        ResetPlayer();

        // Destroy all active enemies instantiated from the example enemy prefab
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if (enemy.gameObject.CompareTag(exampleEnemyPrefab.tag))
            {
                Destroy(enemy.gameObject);
            }
        }

        // Reset other game state
        // ...
    }
}
