using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to be instantiated
    public float attackCooldown = 2f; // Cooldown between attacks
    public float attackRange = 5f; // Maximum distance for attacking
    private Transform player; // Reference to the player's transform
    private float lastAttackTime; // Time when the last attack was performed
    // Start is called before the first frame update
    void Start()
    {
        // Find the player object using its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Check if the player object exists
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure to tag the player object with 'Player'");
        }

        // Set the initial attack time to ensure the enemy can attack immediately
        lastAttackTime = -attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is within range and cooldown has passed
        if (player != null && Time.time - lastAttackTime >= attackCooldown)
        {
            // Calculate the distance between enemy and player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Check if the player is within attack range
            if (distanceToPlayer <= attackRange)
            {
                // Attack the player
                Attack();
            }
        }
    }

    void Attack()
    {
        // Instantiate a projectile at the enemy's position and rotation
        Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Update the last attack time
        lastAttackTime = Time.time;
    }
}
