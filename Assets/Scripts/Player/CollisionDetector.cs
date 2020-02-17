using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask TerrainLayer;

    private float checkRadius = 0.2f; //Cambiar a un check radius de 0.05f o lo que parezca pertinente

    [SerializeField]
    private Transform GroundCollider;

    [SerializeField]
    private bool isGrounded;
    public bool IsGrounded => isGrounded;

    [SerializeField]
    private Transform LeftWallCollider;

    [SerializeField]
    private bool isLeftWalled;
    public bool IsLeftWalled => isLeftWalled;

    [SerializeField]
    private Transform RightWallCollider;

    [SerializeField]
    private bool isRightWalled;
    public bool IsRightWalled => isRightWalled;

    [SerializeField]
    private Transform RoofCollider;

    [SerializeField]
    private bool isRoofed;
    public bool IsRoofed => isRoofed;

    private float distToGround;
    public float groundAngle;

    void FixedUpdate()
    {
        CheckColliders();
        CheckDistanceToGround();
    }

    private void CheckColliders()
    {
        CheckGrounded();
        CheckLeft();
        CheckRight();
        CheckRoof();
    }

    private void CheckGrounded()
    {
        var colliders = Physics2D.OverlapCircleAll(GroundCollider.position, checkRadius, TerrainLayer);
        isGrounded = colliders.Length > 0;
    }

    private void CheckLeft()
    {
        var colliders = Physics2D.OverlapCircleAll(LeftWallCollider.position, checkRadius, TerrainLayer);
        isLeftWalled = colliders.Length > 0;
    }

    private void CheckRight()
    {
        var colliders = Physics2D.OverlapCircleAll(RightWallCollider.position, checkRadius, TerrainLayer);
        isRightWalled = colliders.Length > 0;
    }

    private void CheckRoof()
    {
        var colliders = Physics2D.OverlapCircleAll(RoofCollider.position, checkRadius, TerrainLayer);
        isRoofed = colliders.Length > 0;
    }

    private void CheckDistanceToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(GroundCollider.position,
            Vector2.down, 100, TerrainLayer);

        distToGround = hit.distance;
        groundAngle = Vector2.Angle(hit.normal, new Vector2(1, 0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCollider.position, checkRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(RoofCollider.position, checkRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(LeftWallCollider.position, checkRadius);
        Gizmos.DrawWireSphere(RightWallCollider.position, checkRadius);
    }

}