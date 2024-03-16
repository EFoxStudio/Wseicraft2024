using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;
    Vector2 moveDirection;

    public int hp = 100;

    public float speed = 5f;
    public Animator animator;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldawn = 1f;
    bool isDashing;
    bool canDash = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        canDash = true;
    }

    void Update()
    {

        if (isDashing)
        {
            return;
        }
 
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

        if (moveHorizontal != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveHorizontal)); 
            animator.SetFloat("DirectionX", moveHorizontal); 
            animator.SetFloat("DirectionY", 0); 
            animator.SetBool("horizontal", true);
        }
        else if (moveVertical != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveVertical));
            animator.SetFloat("DirectionX", 0); 
            animator.SetFloat("DirectionY", moveVertical); 
            animator.SetBool("horizontal", false);
        }
        else
        {
            animator.SetFloat("Speed", 0); 
            animator.SetBool("horizontal", false);
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (hp <= 0)
        {
            SceneManager.LoadScene("wypierdolka");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }
        spriteRenderer.flipX = rb.velocity.x < 0f;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        animator.SetTrigger("Dash");
        rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldawn);
        canDash = true;
    }
}
