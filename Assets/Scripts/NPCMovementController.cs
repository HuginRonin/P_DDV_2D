using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool fleeing = false;
   
    private void FixedUpdate()
    {
        if (fleeing)
        {
            transform.Translate(new Vector3(speed, 0, 0));
        }
    }

    public void Flee()
    {
        fleeing = true;
    }
}
