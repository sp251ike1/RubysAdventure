using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{ 
    public AudioClip collectedCoin;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        // Check if controller is not null before proceeding
        if (controller != null)
        {
            controller.PlaySound(collectedCoin);
            controller.ChangeSpeed(6);
            Destroy(gameObject);
        }
    }
}