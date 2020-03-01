using System;
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
    [SerializeField]
    private float attackRange;

    private DamageDealer dmg;
    private PlayerDetection detect;
    private Animator ator;
    // Start is called before the first frame update
    void Start()
    {
        detect = GetComponent<PlayerDetection>();
        ator = GetComponent<Animator>();
        dmg = GetComponentInChildren<DamageDealer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EdgeDetected())
        {
            Flip();
        }

        if (detect.PlayersDetected.Length > 0)
        {
            AttackMode();
        }
        else
        {
            dmg.enabled = false;
            ator.SetBool("Attack", false);
            Move();
        }
      
    }

    private void AttackMode()
    {
        dmg.enabled = true;

        Transform t = detect.PlayersDetected[0].transform;
        Vector3 dir = (t.position - transform.position);
        dir.y = 0;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);
        
        if(dir.magnitude < attackRange)
        {
            ator.SetBool("Attack", true);
        }       
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
