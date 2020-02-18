using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalForces : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bounce(Bouncer b, Vector2 force)
    {
        
        gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
