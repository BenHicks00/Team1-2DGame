using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Healthbar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"[Start] Initializing health: {currentHealth}/{maxHealth}"); // Debugging
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"[TakeDamage] Before: {currentHealth}/{maxHealth}");
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        Debug.Log($"[TakeDamage] After: {currentHealth}/{maxHealth}");

        healthBar.SetHealth(currentHealth); // Update the health bar

        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        Debug.Log($"[Heal] Before: {currentHealth}/{maxHealth}");
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        Debug.Log($"[Heal] After: {currentHealth}/{maxHealth}");

        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add respawn logic here or restart the scene
    }
}