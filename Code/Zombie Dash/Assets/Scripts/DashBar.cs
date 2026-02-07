using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public static DashBar instance;  // Instance of this class that is used in the "Movement" script

    public Slider dashBar;  // Slider reference 

    private int maxStamina = 80;
    private int currentStamina;

    private WaitForFixedUpdate regenTick = new WaitForFixedUpdate();  // Sinks up the dash bar to the countdown in the "Movement" script 

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        dashBar.maxValue = maxStamina;
        dashBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            dashBar.value = currentStamina;

            StartCoroutine(RegenStamina());  // Starts the regeneration of the dash bar
        }
    }

    private IEnumerator RegenStamina()
    {
        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 80;
            dashBar.value = currentStamina;  // Updates the actual dash bar in game
            yield return regenTick;
        }
    }
}
