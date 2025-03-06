using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthBar;
    private float maxHealth;
    private float currentHealth;

    public void SetMaxHealth(float hp)
    {
        maxHealth = hp;
        currentHealth = hp;
        Debug.Log($"Setting max health: {maxHealth}"); // Debugging
        UpdateHealthBar();
    }

    public void SetHealth(float hp)
    {
        currentHealth = hp;
        Debug.Log($"Updating health bar: {currentHealth} / {maxHealth}"); // Debugging
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        Debug.Log($"Player took damage! New health: {currentHealth}");
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
            Debug.Log($"Health Bar Updated: {healthBar.fillAmount}");
        }
        else
        {
            Debug.LogWarning("HealthBar Image reference is missing!");
        }
    }
}
