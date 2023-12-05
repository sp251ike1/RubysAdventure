﻿//Modified script made by Caio Simonetta
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class DamageZone : MonoBehaviour 
{

    public ParticleSystem particleEffect;

    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(-2);   //increase playerHealth by a value of 1

        }
    }
}
