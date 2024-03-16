using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        
    }

    public void Update()
    {

    }

    public void ChangeSpeed(bool isNight)
    {
        if (isNight)
        {
            rb.velocity *= 3;

        }
        else
        {
            rb.velocity /= 15;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
        }

        Destroy(gameObject);
    }
}
