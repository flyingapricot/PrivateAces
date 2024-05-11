using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public HealthBar healthBar;  // Reference to the HealthBar component

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);  // Initialize the health bar
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        healthBar.SetHealth(currentHealth);  // Update the health bar on taking damage
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);  // Update the health bar on healing
    }
}

