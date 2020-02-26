using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float windForce;
    public float angle;
    Vector3 direction => Quaternion.AngleAxis(angle, Vector3.forward) * transform.right;

    void OnTriggerStay2D(Collider2D other)
    {
        var reciever = other.GetComponent<ExternalForces>();
        if (reciever)
        {
            Debug.Log("si");
            var force = windForce * direction;
            reciever.Bounce(force);

            //other.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse); 
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, direction * windForce);
    }
}
