using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMele : MonoBehaviour
{
    public float attackDuration = 0.5f; // Time required for continuous contact to initiate attack
    private float attackTimer = 0f; // Timer to track contact duration
    public int attack = 30;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if collided with the player
        {
            attackTimer = 0f; // Reset the attack timer when collision occurs
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if still in contact with the player
        {
            attackTimer += Time.deltaTime; // Increment the timer while in contact

            if (attackTimer >= attackDuration) // Check if attack duration threshold is met
            {
                // Perform attack action here
                Debug.Log("Enemy attacking player!");

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().hp -= attack;

                // Reset the attack timer after attacking
                attackTimer = 0f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if no longer in contact with the player
        {
            attackTimer = 0f; // Reset the attack timer when contact ends
        }
    }

}
