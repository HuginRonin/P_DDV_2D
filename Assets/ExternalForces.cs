using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalForces : MonoBehaviour
{
    MovementController mov;
    
    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bounce(Vector2 force)
    {
        mov.TriggerEffect(force);
    }
}
