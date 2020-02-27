using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform EdgeDetector;
    public LayerMask Ground;
    [SerializeField]
    private float Speed;
    public float lookGroundDistance;
    public float lookWallDistance;
    [SerializeField]
    private float groundAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EdgeDetected())
        {
            Flip();
        }

        Move();
    }

    private void FixedUpdate()
    {
        
    }

    bool EdgeDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(EdgeDetector.position, -Vector2.up, lookGroundDistance, Ground);
        groundAngle = Vector2.Angle(hit.normal, new Vector2(1, 0));
        return hit.collider == null;
    }

    void Flip()
    {
        transform.Rotate(0,180,0);
    }

    private void Move()
    {
        Vector3 dir = transform.right;
        transform.Translate(dir * Speed * Time.deltaTime, Space.World);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(EdgeDetector.position, Vector2.down * lookGroundDistance);
        Gizmos.DrawRay(EdgeDetector.position, Vector2.right * lookWallDistance);
    }
}
