using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHP : MonoBehaviour
{
    public int health;
    public AudioSource healthSound;
    public AudioSource damageSound;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(GoToEndGameScene());  // Go to the game over scene (menu) after 0.5 seconds

            Debug.Log("Player dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If colliding with a zombie, then the player loses 25 hp
        if (IsZombie(collision))
        {
            health -= 25;
            HealthBar.instance.TakeDamage(25);  // Updates the player HP bar
            damageSound.Play();
        }

        // If the player is colliding with a large health pack, then restore their health to full (100)
        if (IsLargeHealthPack(collision))
        {
            health = 100;
            HealthBar.instance.MaxHP();  // Update hp bar to full hp
            healthSound.Play();
            Destroy(collision.gameObject);  // Destroy the healh pack after use
        }

        // If the player is colliding with a small health pack, then restore their by 25 if below 100 hp
        if (IsSmallHealthPack(collision))
        {
            if (health < 100)
            {
                health += 25;
                HealthBar.instance.RestoreHP(25);  // Update Hp bar
            }
            healthSound.Play();
            Destroy(collision.gameObject);  // Destory health pack after use
        }
    }
    
    // Checks if the collision GameObject has a Zombie tag
    private bool IsZombie(Collision2D collision)
    {
        return collision.gameObject.CompareTag("Zombie");  // CompareTag is the same thing as == but more efficient
    }

    // Checks if the collision GameObject has a SmallHealthPack tag
    private bool IsSmallHealthPack(Collision2D collision)
    {
        return collision.gameObject.CompareTag("SmallHealthPack");
    }

    // Checks if the collision GameObject has a LargeHealthPack tag
    private bool IsLargeHealthPack(Collision2D collision)
    {
        return collision.gameObject.CompareTag("LargeHealthPack");
    }

    private IEnumerator GoToEndGameScene()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Go to the game over scene
    }
}
