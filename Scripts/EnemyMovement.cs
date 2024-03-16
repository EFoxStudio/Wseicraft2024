using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Speed of the enemy
    public float speedModifier = 1f;
    public Animator animator;
    private Transform player; // Reference to the player's transform

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
        animator.SetFloat("Speed", (speed * speedModifier));
        
        // Check if player is within range
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position += direction * speed * speedModifier * Time.deltaTime;

            if(Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                animator.SetFloat("DirectionY", direction.y);
                animator.SetFloat("DirectionX", 0);
            }
            else
            {
                animator.SetFloat("DirectionX", direction.x);
                animator.SetFloat("DirectionY", 0);
            }


            UnityEngine.Debug.Log(direction);
        }
    }

}
