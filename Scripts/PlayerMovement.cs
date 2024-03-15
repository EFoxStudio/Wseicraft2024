using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speedModifier;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player object
    }

    void Update()
    {
        // Input handling for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Apply movement to the Rigidbody2D
        rb.velocity = movement * speedModifier;

        // rb.velocity = new Vector2(moveHorizontal * speedModifier, rb.velocity.y);
    }
}
