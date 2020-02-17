using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private MovementController mc;
    private CollisionDetector colDetect;

    [SerializeField]
    private float JumpHeight;

    [SerializeField]
    private float PlaceToMaxHeight;

    private float horizontalSpeed;

    private float lastYVelocity;
    [SerializeField]
    private float gravAlter;
    private float jumpStartedTime;
    [SerializeField]
    private float MinPressJumpTime;
    [SerializeField]
    private float MaxPressJumpTime;

    private float numberOfJumps;
    [SerializeField]
    private float maxJumps;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mc = GetComponent<MovementController>();
        horizontalSpeed = mc.maxSpeed;
        colDetect = GetComponent<CollisionDetector>();
    }

    private void FixedUpdate()
    {
        if (PeakReached())
        {
            AlterGravity();
        }

        if (colDetect.IsGrounded)
        {
            numberOfJumps = 1;
            rb2D.gravityScale = 1;
        }
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * horizontalSpeed / PlaceToMaxHeight;
    }

    private void SetGravity()
    {
        var grav = 2 * JumpHeight * horizontalSpeed * numberOfJumps / (PlaceToMaxHeight * PlaceToMaxHeight);
        rb2D.gravityScale = grav / 9.81f;
    }

    private bool PeakReached()
    {
        bool reached = (lastYVelocity * rb2D.velocity.y) < 0;
        lastYVelocity = rb2D.velocity.y;
        return reached;
    }

    private void AlterGravity()
    {
        rb2D.gravityScale *= gravAlter; 
    }

    public void OnJumpStart()
    {
        if (numberOfJumps < maxJumps)
        {
            SetGravity();
            Vector2 vel = new Vector2(rb2D.velocity.x, GetJumpForce());
            rb2D.velocity = vel;  
            jumpStartedTime = Time.time;
            numberOfJumps++;
        }

        
    }

    public void OnJumpEnd()
    {
        float timePressed = 1 / Mathf.Clamp01(Mathf.Max(MinPressJumpTime,(Time.time - jumpStartedTime)) / MaxPressJumpTime);
        rb2D.gravityScale *= timePressed;
    }


}
