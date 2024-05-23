using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLeft : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*-1 * speed;
    }

    // Add collision detection methods here as needed
    void OnCollisionEnter2D(Collision2D collision)
    {
        // For example, destroy the projectile on collision
        Destroy(gameObject);
    }
}
