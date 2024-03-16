using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackCooldown = 2f;
    public float bulletForce = 20f;
    private Transform player;
    private Transform shooting;
    private float lastAttackTime;
    public float attackRange = 100f;

    void Start()
    {
        lastAttackTime = -attackCooldown;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shooting = GameObject.FindGameObjectWithTag("FirePoint").transform;

    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RotateTowardsPlayer(direction);

        if (player != null && Time.time - lastAttackTime >= attackCooldown)
        {
            // Calculate the distance between enemy and player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Check if the player is within attack range
            if (distanceToPlayer <= attackRange)
            {
                // Attack the player
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        lastAttackTime = Time.time;
    }

    void RotateTowardsPlayer(Vector3 direction)
    {
        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation to the enemy
        shooting.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
