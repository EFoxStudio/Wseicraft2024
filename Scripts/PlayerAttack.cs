using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AnimationClip attack1Animation;
    public AnimationClip attack2Animation;
    public AnimationClip attack3Animation;

    public float dashSpeed = 10f; // Adjust this value to control dash speed
    public float dashDuration = 0.5f; // Adjust this value to control dash duration

    private Rigidbody2D rb;
    private Animator animator;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player object
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player object
    }

    void Update()
    {
        // Attack input handling
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("attack1");
            Attack(attack1Animation);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("attack2");
            Attack(attack2Animation);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("attack3");
            Attack(attack3Animation);
        }

        // Dash input handling
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    void Attack(AnimationClip animation)
    {
        // Play the specified animation
        animator.Play(animation.name);
        Debug.Log("Animation executed");
        // Add attack logic here if needed
    }

    void Dash()
    {
        isDashing = true;
        // Disable player movement while dashing
        rb.velocity = Vector2.zero;
        // Apply dash effect
        rb.velocity = transform.right * dashSpeed;
        // Invoke a method to stop dashing after a duration
        Invoke("StopDash", dashDuration);
    }

    void StopDash()
    {
        isDashing = false;
        // Stop the player's movement
        rb.velocity = Vector2.zero;
        //cops
    }

}
