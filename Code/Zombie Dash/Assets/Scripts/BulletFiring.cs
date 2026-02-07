using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public Transform firePoint;  // REFERNCE: Origin point of bullets
    public GameObject bulletPrefab; // REFERNCE: Bullet prefab

    public float bulletForce = 20f;
    public AudioSource bulletSound;

    private float roundsPerSecond = 5f;
    private float cooldownTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;

        // NOTE: This input system might be depreciated. Look for information about Unity's new input system.
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }

        void Shoot()
        {
            if (cooldownTime < currentTime)
            {
                // Set bullet cooldown
                cooldownTime = currentTime + (1f / roundsPerSecond);

                // Create a new bullet
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                // Apply force to bullet's rigid body
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

                // Play Bullet Sound
                bulletSound.Play();
            }
        }
    }
}
