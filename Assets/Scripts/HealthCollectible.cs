using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1); //increase playerHealth by a value of 1
                Destroy(gameObject);        //destroy the object that gave health

                controller.PlaySound(collectedClip);    //play collectedHealth sound

            }
        }

    }
}