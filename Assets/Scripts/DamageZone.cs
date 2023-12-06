//SCRIPT MADE BY STANLEY FREIHOFER



//line 21 modifed by Caio Simnetta
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class DamageZone : MonoBehaviour         //made by Stanley Freihofer
{

    public ParticleSystem particleEffect;

    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {

            controller.ChangeHealth(-2);   //ORIGNAL LINE MADE BY STANLEY FREIHOFER (ORIGINAL VALUE WAS -1). CAIO SIMONNETTA CHANGED THE VALUE TO -2

        }
    }
}
