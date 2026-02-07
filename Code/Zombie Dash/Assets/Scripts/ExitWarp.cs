using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitWarp : MonoBehaviour
{
    public List<Vector2> spawnLocations;  // Set coordinates in editor

     /**
      * Spawn Locations
      * (-19.72, -73.46), // South-west fountain
      * (2.74,  -28.86),  // East fountain
      * (61.29,  9.01)    // North-east fountain
     **/

    void OnEnable()
    {
        // Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    } 

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        // Move exit warp to a random listed location
        transform.position = spawnLocations[Random.Range(0, spawnLocations.Count)];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            SceneManager.LoadScene(nextSceneId);
        }
    }

    void OnDisable()
    {
        // Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled.
        // Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    [Header("Scene Load Options")]
    [SerializeField] private int nextSceneId = default;
}
