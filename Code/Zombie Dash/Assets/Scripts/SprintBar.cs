using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public static SprintBar instance;  // Instance of this class that is used in the "Movement" script

    public Slider sprintBar;  // Slider reference 

    private int maxStamina = 100;
    public static int currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);  // Tickrate for sprint bar regen

    private Coroutine regen;  // Coroutine to disable regen after each sprint call

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        sprintBar.maxValue = maxStamina;
        sprintBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            sprintBar.value = currentStamina;

            // Restarts the 2 second countdown until regeneration start after each sprint
            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());  // Starts the regeneration
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);  // Waits two seconds before starting regen

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            sprintBar.value = currentStamina;  // Update the actual bar in the scene 
            yield return regenTick;
        }

        regen = null;
    }
}
