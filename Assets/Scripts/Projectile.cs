using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;  // Made by Daniel Chaviano
    bool returning = false;   // Flag to indicate if the projectile should return

    void Awake()  // Made by Daniel Chaviano
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)  // Made by Daniel Chaviano
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()  // Made by Daniel Chaviano
    {
        if (!returning && transform.position.magnitude > 1000.0f)
        {
            ReturnProjectile();  // Made by Daniel Chaviano  // Call a function to handle the return
        }
    }

    void ReturnProjectile()  // Made by Daniel Chaviano
    {
        // Reverse the direction and set the flag to indicate the projectile is returning
        rigidbody2d.velocity = -rigidbody2d.velocity;
        returning = true;  // Made by Daniel Chaviano
    }

    void OnCollisionEnter2D(Collision2D other)  // Made by Daniel Chaviano
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();

        if (e != null)
        {
            e.Fix();
            ReturnProjectile();  // Made by Daniel Chaviano  // Call the return function when hitting an enemy
        }

        // Uncomment the line below if you want the projectile to be destroyed after hitting an enemy
        // Destroy(gameObject);
    }
}
