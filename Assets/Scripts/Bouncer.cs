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
            
            //other.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse); 
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, direction * bounceForce);
    }
}
