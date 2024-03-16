using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public Transform attackPoint;
    public Transform attackPointLeft;
    public Transform attackPointUp;
    public Transform attackPointDown;
    Transform point;

    public LayerMask enemyLayers;
    public PlayerMovement pm;

    public int attackDamage = 30;

    public float attackRate = 2f;
    public float attackRange = 0.5f;
    public float dashSpeed = 10f; 
    public float dashDuration = 0.2f;
    float nextAttackTime = 0f;

    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
       
        // Dash input handling
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        if(pm.moveHorizontal > 0)
        {
            point = attackPoint;
        }else if(pm.moveHorizontal < 0)
        {
            point = attackPointLeft;
        }else if(pm.moveVertical > 0)
        {
            point = attackPointUp;
        }else if(pm.moveVertical < 0)
        {
            point = attackPointDown;
        }
        else
        {
            point = attackPoint;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(point.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We  hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (point == null)
            return;

        Gizmos.DrawWireSphere(point.position, attackRange);
    }

    void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            // Disable player movement while dashing
            rb.velocity = Vector2.zero;
            // Apply dash effect
            rb.velocity = transform.right * dashSpeed;
            // Invoke a method to stop dashing after a duration
            Invoke("StopDash", dashDuration);
        }
    }

    void StopDash()
    {
        isDashing = false;
        // Enable player movement again after dashing
        rb.velocity = Vector2.zero;
    }

}
