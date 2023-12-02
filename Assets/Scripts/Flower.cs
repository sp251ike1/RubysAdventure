//SCRIPT MADE BY STANLEY FREIHOFER

using UnityEngine;

public class FlowerCollision : MonoBehaviour
{

    public AudioClip Flower;

    void OnTriggerEnter2D(Collider2D other)
    {

        RubyController controller = other.GetComponent<RubyController>();

        // Check if controller is not null before proceeding
        if (controller != null)
        {
            controller.PlaySound(Flower);
            controller.ChangeSpeed(-2);
            Debug.Log(controller.speed);


        }
    }
}