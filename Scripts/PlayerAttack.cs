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
    float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
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

        if (hitEnemies.Length > 0)
        {
            Camera.main.GetComponent<Shake>().ShakeCam(0.03f);

        }
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
}
