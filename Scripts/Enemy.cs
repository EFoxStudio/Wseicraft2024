using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public Animator animator;
    int currentHealth;
    public GameObject particle;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(particle, gameObject.transform);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        
        if(currentHealth <= 0) {
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
