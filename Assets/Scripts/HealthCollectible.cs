using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip1;
    public ParticleSystem collectParticle;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        // Check if controller is not null before proceeding
        if (controller != null)
        {
            controller.PlaySound(collectedClip1);

            // Play particle system before destroying the GameObject
            if (collectParticle != null)
            {
                collectParticle.Play();
            }

            // Check if player's health is less than max health
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
            }

            // Destroy the GameObject after collecting health
            Destroy(gameObject);
        }
    }
}