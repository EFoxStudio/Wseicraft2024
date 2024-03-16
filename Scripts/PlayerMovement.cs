using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;

    public float speed = 5f;
    public Animator animator;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Input handling for movement
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        bool horizontal = false;

        // Set animator parameters based on movement direction
        if (moveHorizontal != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveHorizontal)); // Set speed for side movement
            animator.SetFloat("DirectionX", moveHorizontal); // Set direction for side movement
            animator.SetFloat("DirectionY", 0); // Reset vertical direction
            animator.SetBool("horizontal", true);
        }
        else if (moveVertical != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveVertical)); // Set speed for up/down movement
            animator.SetFloat("DirectionX", 0); // Reset horizontal direction
            animator.SetFloat("DirectionY", moveVertical); // Set direction for up/down movement
            animator.SetBool("horizontal", false);
        }
        else
        {
            animator.SetFloat("Speed", 0); // No movement
            animator.SetBool("horizontal", false);
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

    }

    private void FixedUpdate()
    {
        
        // Apply movement to the Rigidbody2D
        spriteRenderer.flipX = rb.velocity.x < 0f;
    }
}
