using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    // Transitions the scene to the next scene in the Unity Build Index
    public void PlayGame ()
    {
        RemoveSelectHighlight();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        RemoveSelectHighlight();
        Application.Quit();  // Quits the game
    }

    // Removes the "feature" of when you click on a button, it is "selected"
    // When "selected", it makes it so the "on hover" feature does not work
    // This function removes the "selected" objected from the queue to make
    // highligthing work again.
    public void RemoveSelectHighlight ()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
