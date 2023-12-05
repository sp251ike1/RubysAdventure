using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    bool returning = false; // Flag to indicate if the projectile should return

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        if (!returning && transform.position.magnitude > 1000.0f)
        {
            ReturnProjectile(); // Call a function to handle the return
        }
    }

    void ReturnProjectile()
    {
        // Reverse the direction and set the flag to indicate the projectile is returning
        rigidbody2d.velocity = -rigidbody2d.velocity;
        returning = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();

        if (e != null)
        {
            e.Fix();
            ReturnProjectile(); // Call the return function when hitting an enemy
        }

        // Uncomment the line below if you want the projectile to be destroyed after hitting an enemy
        // Destroy(gameObject);
    }
}
