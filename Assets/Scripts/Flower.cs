//SCRIPT MADE BY STANLEY FREIHOFER

using UnityEngine;

public class FlowerCollision : MonoBehaviour
{

    public AudioClip Flower;
    public int SpeedDecreaser = -1;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        RubyController controller = other.GetComponent<RubyController>();

        // Check if controller is not null before proceeding
        if (controller != null)
        {
            controller.PlaySound(Flower);
            controller.ChangeSpeed(SpeedDecreaser);
            Debug.Log(controller.speed);


        }
    }
}