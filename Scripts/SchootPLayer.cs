using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchootPLayer : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform spawnPoint; // Point where the projectile will spawn
    public float fireRate = 0.5f; // Rate of fire (in seconds)
    public float defaultBulletSpeed = 10f; // Default speed of the bullet
    private float nextFireTime = 0f; // Time to fire next

    void Update()
    {
        // Check if the fire button is pressed and if it's time to shoot again
        if (Input.GetButtonDown("Fire2") && Time.time >= nextFireTime)
        {
            Shoot(); // Call the Shoot method
            nextFireTime = Time.time + fireRate; // Update the next fire time
        }
    }

    void Shoot()
    {
        spawnPoint = transform;
        // Calculate direction from the spawn point to the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - spawnPoint.position).normalized;

        // Instantiate a projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        // Get the rigidbody component of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Check if the rigidbody component exists
        if (rb != null)
        {
            // Set the bullet speed based on the default speed
            float bulletSpeed = defaultBulletSpeed;

            // Apply force to the projectile to shoot it in the calculated direction
            rb.velocity = direction * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Projectile prefab does not have a Rigidbody2D component.");
        }
    }
}

