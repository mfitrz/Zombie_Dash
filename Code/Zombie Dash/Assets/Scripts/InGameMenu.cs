using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// NEED TO ATTACH TO SOMETHING THAT IS ALWAYS ENABLED IN THE SCENE
// NOT THE ACTUAL IN-GAME MENU !!!!!!
// THIS SAME OBJECT NEEDS TO BE ATTACHED TO THE BUTTONS AS WELL !!!!
// --- NEED EVENT SYSTEM IN JANGS LEVEL ---
// REMINDER FOR OPTIONS IN-GAME SUB-MENU: ADD THE SAME OBJECT FOR THE BACK BUTTON REFERENCE ON CLICK EVENT AND REMOVEHIGHLIGHTSELECT

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;  // Reference to the in-game menu object

    // Start is called before the first frame update
    void Start()
    {   
        // Disables the in-game menu by default
        inGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // The user can press the ESC key on their keyboard to open up the in-game menu
        // The user must press the "BACK" button in the menu to close the in-game menu
        if (Input.GetKeyDown(KeyCode.Escape) && inGameMenu.activeSelf == false)
        {
            inGameMenu.SetActive(true);  // Shows the in-game menu on screen

            Time.timeScale = 0;  // Pauses the game when the menu is open
            
            /* 
             * NO NEED FOR THIS BECAUSE THE CURSOR IS ALREADY ENABLED BY DEFAULT 
             * 
            // Makes the mouse cursor visible and able to move freely
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            */
        }

    }

    public void Exit ()
    {
        RemoveSelectHighlight();
        Application.Quit();
    }

    // Hides the in-game menu once the user presses the "BACK" button
    public void Back ()
    {
        RemoveSelectHighlight();

        /*
         * NO NEED FOR THIS BECAUSE THE CURSOR IS ALREADY ENABLED BY DEFAULT
         * 
        // Makes the mouse disappear and locks the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        */

        inGameMenu.SetActive(false);  // Hides the in-game menu
        
        Time.timeScale = 1;  // Resumes the game 
    }

    // Removes the "feature" of when you click on a button, it is "selected"
    // When "selected", it makes it so the "on hover" feature does not work
    // This function removes the "selected" objected from the queue to make
    // highligthing work again.
    public void RemoveSelectHighlight()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
