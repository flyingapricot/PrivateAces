using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth = 100f;
    public float maxHealth = 100f;

    void Start()
    {
        healthBar = GetComponent<Image>();
        UpdateHealthBar();  // Call to update health bar on start
    }

    void Update()
    {
        // Call this only if health changes occur to improve performance
    }

    // Method to set health directly
    public void SetHealth(float health)
    {
        currentHealth = health;
        UpdateHealthBar();
    }

    // Method to update the health bar UI
    private void UpdateHealthBar()
    {
        float healthRatio = currentHealth / maxHealth;
        healthBar.fillAmount = healthRatio;
        healthBar.color = Color.Lerp(Color.red, Color.green, healthRatio);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        UpdateHealthBar();  // Update health bar after taking damage
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        UpdateHealthBar();  // Update health bar after healing
    }
}

