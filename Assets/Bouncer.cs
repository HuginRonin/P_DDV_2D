using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForce;
    public float angle;
    Vector3 direction => Quaternion.AngleAxis(angle, Vector3.forward) * transform.right;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        var reciever = other.GetComponent<ExternalForces>();
        if (reciever)
        {
            Debug.Log("si");
            var force = bounceForce * direction;
            reciever.Bounce(force);
            //o
            //other.GetComponent<RigidBody2D>.AddForce(force, ForceMode2D.Impulse); //asegurarse de que esté todo
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, direction * bounceForce);
    }
}
