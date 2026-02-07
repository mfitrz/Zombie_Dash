using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAKE SURE TO MAKE THE ZOMBIE SORTING LAYER IS GROUND AFTER FIXING SPAWNING
public class ZombieHP : MonoBehaviour
{
    public int health;
   
    public GameObject blink;  // Reference to the white sprite
    public List<GameObject> itemsToDropPool;  // List of GameObjects that the zombies can potentially drop after dying

    // Start is called before the first frame update
    void Start()
    {
        health = 300;
    }

    // Update is called once per frame
    void Update()
    {   
        // Desspawn the GameObject that this script is attached too after health reaches 0
        if (health <= 0)
        {
            int itemToSpawnIndex = Random.Range(0, itemsToDropPool.Count);  // Randomly selects an item from the drop pool

            GameObject actualItemToSpawn = itemsToDropPool[itemToSpawnIndex];  // Selects the item to spawn from the drop pool

            // 20% chance of spawning a small health pack
            if (Random.value <= 0.20 && actualItemToSpawn.CompareTag("SmallHealthPack"))
            {
                SpawnItem(actualItemToSpawn);  // Spawns the small health pack where the zombie was
            }

            // 10% chance of spawning a large health pack
            if (Random.value <= 0.10 && actualItemToSpawn.CompareTag("LargeHealthPack"))
            {
                SpawnItem(actualItemToSpawn);  // Spawns the large hp pack where the zombie was
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if what is hitting it is a bullet. 
        if (collision.gameObject.name == "BulletPrefab(Clone)")  // This is what the bullet object is called
        {
            health -= 100;  // Makes the zombie take 3 shots to kill

            StartCoroutine(Blink());  // Makes the zombie sprite blink
        }

    }

    // Waits 0.1 seconds to make the blink sprite appear and disappear
    public IEnumerator Blink()
    {
        blink.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        blink.SetActive(false);
    }

    // Spawns passed in GameObject to the location of this GameObject (the GameObject this script is attached to)
    private void SpawnItem(GameObject itemToSpawn)
    {
        Instantiate(itemToSpawn, gameObject.transform.position, gameObject.transform.rotation);
    }
}
