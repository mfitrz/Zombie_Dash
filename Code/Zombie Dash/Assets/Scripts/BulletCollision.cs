using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // public GameObject hitEffect;  // REFERENCE: Bullet collision graphic(s)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Create bullet collision effect
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);  // Delay destory by n seconds
        Destroy(gameObject);
    }

    // Function executed when object is not visible by any camera.
    // Intended use is when bullet goes out of bounds without colliding on anything.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
