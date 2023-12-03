//SCRIPT MADE BY STANLEY FREIHOFER

using UnityEngine;

public class FlowerCollision : MonoBehaviour
{

    public AudioClip Flower;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        RubyController controller = other.GetComponent<RubyController>();

        // Check if controller is not null before proceeding
        if (controller != null)
        {
            controller.PlaySound(Flower);
            //controller.speed = 3;
            controller.ChangeSpeed(3);
            Debug.Log(controller.speed);


        }
    }
}