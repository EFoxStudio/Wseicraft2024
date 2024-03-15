using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy
    public float defaultSpeed = 2f;
    public float speedModifier = 1f;
    private Transform player; // Reference to the player's transform
    public bool isNight;
    public float seeRange = 10;

    public int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player object using its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Check if the player object exists
        if (player == null)
        {
            UnityEngine.Debug.Log("Player not found! Make sure to tag the player object with 'Player'");
        }
    }

    // Update is called once per frame
    void Update()
    {

        float playerVelocity = Math.Abs(player.GetComponent<Rigidbody2D>().velocity.x) + Math.Abs(player.GetComponent<Rigidbody2D>().velocity.y);
        playerVelocity *= 0.2f;
        if (playerVelocity != 0)
        {
           speed = playerVelocity;
           speed *= -1;
        }
        else
        {
            speed = defaultSpeed;
        }

        if (speed < 0)
            speed = 0;

        if (speed == 0)
            speed = 0.2f;

        //UnityEngine.Debug.Log("plyer velocity: " + playerVelocity + "   enemy velocity: " + speed);

        // Check if player is within range

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (player != null && distanceToPlayer < seeRange)
        {
            // Calculate the direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position += direction * speed * speedModifier * Time.deltaTime;

            // Optionally, rotate the enemy to face the player
            RotateTowardsPlayer(direction);
        }
    }

    void RotateTowardsPlayer(Vector3 direction)
    {
        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation to the enemy
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

}
