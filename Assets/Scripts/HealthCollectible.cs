using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip1;
    public ParticleSystem collectParticle;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        controller.PlaySound(collectedClip1);    //play collectedHealth sound
        collectParticle.Play();
        //controller.Particle(collectParticle);

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1); //increase playerHealth by a value of 1
                Destroy(gameObject);        //destroy the object that gave health



            }
        }

    }
}