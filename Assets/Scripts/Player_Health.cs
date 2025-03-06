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
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
{
    currentHealth -= damage;
    if (currentHealth < 0) currentHealth = 0;

    Debug.Log($"Player took damage! Current Health: {currentHealth}"); // Debugging

    healthBar.SetHealth(currentHealth); // Update the health bar

    if (currentHealth == 0)
    {
        Die();
    }
}


    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add respawn logic here or restart the scene
    }
}