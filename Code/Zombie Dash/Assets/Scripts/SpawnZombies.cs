using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAKE SURE THE TAG FOR THE OBJECT YOU ARE TRYING TO SPAWN IS "SPAWNABLE"
// AND ADD THEM TO THE SPAWN LIST
// MAKE AN EMPTY GAME OBJECT CALLED "SPAWNER" AND ATTACH THIS SCRIPT TO IT

// MAKE SURE TO MAKE THE ZOMBIE SORTING LAYER IS GROUND AFTER FIXING SPAWNING
public class SpawnZombies : MonoBehaviour
{
    public int numberToSpawn;  // Number of GameObjects to spawn randomly (ASSIGN THIS IN EDITOR)
    public List<GameObject> spawnList;  // List of GameObjects that can be potentially chosed to spawn (ASSIGN THIS IN EDITOR)
    public GameObject quad;  // Reference to Quad GameObject (Scale this to the size of the map)

    void Start()
    {
       SpawnObjects();  // Spawn the zombies at the start
    }

    // Source: https://www.youtube.com/watch?v=4OQjnKUENoE&t=757s
    public void SpawnObjects ()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider collider = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnList.Count);
            toSpawn = spawnList[randomItem];

            screenX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            screenY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }

    private void destroyObjects()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable")) 
        {
            Destroy(o);
        }
    }
   
}
