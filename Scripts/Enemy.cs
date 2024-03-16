using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public Animator animator;
    int currentHealth;
    public GameObject particle;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(particle, gameObject.transform);
            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator ApplyTransparencyEffect()
    {
        // Set sprite transparency to 50%
        Color transparentColor = spriteRenderer.color;
        transparentColor.a = 0.5f;
        spriteRenderer.color = transparentColor;

        // Wait for half a second
        yield return new WaitForSeconds(0.5f);

        // Reset sprite transparency to original value
        transparentColor.a = 1;
        spriteRenderer.color = transparentColor;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        StartCoroutine(ApplyTransparencyEffect());
        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
 
}
