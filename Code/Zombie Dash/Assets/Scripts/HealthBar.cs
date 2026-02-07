using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;  // Instance of this class that is used in the "Movement" script

    public Slider healthBar;  // Slider reference 

    private readonly int maxHealth = 100;
    public static int currentHealth;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth - amount >= 0)
        {
            currentHealth -= amount;
            UpdateInGameHealthBar();
        }
    }

    public void RestoreHP(int amount)
    {
        currentHealth += amount;
        UpdateInGameHealthBar();

    }

    public void MaxHP()
    {
        currentHealth = 100;
        UpdateInGameHealthBar();
    }

    // Updates the actual health bar that is shown in the game with the current health value
    private void UpdateInGameHealthBar()
    {
        healthBar.value = currentHealth;
    }
    
}
