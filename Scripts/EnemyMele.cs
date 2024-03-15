using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMele : MonoBehaviour
{
    public float attackCooldown = 2f; // Cooldown between attacks
    public float attackRange = 1.5f; // Distance at which the enemy will start attacking
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
        // Here you can put code to damage the player or trigger an animation, etc.
        Debug.Log("Attacking player!");
        player.GetComponent<PlayerMovement>().health -= 3;
        Debug.Log("Player hp: " + player.GetComponent<PlayerMovement>().health);

        // Update the last attack time
        lastAttackTime = Time.time;
    }
}
