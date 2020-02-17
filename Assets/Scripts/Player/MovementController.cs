using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CollisionDetector))]
public class MovementController : MonoBehaviour
{ 
    private CollisionDetector colDetect;
    private Rigidbody2D rb2D;

    public float maxSpeed;
    private float acceleration = 5.0f;
    private float decceleration = 5f;
    [SerializeField]
    private float deccelerationCoefficient;
    private float currentSpeed = 0.0f;
    private bool stopping = true;
    private bool goingRight=false;
    [SerializeField]
    private float RampDrag;
    private bool OnRamp;
    // Start is called before the first frame update
    void Start()
    {
        colDetect = GetComponent<CollisionDetector>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(colDetect.groundAngle - 90 > 1)
        {
            OnRamp = true;
        }
        else
        {
            OnRamp = false;
        }

        if (OnRamp)
        {
            if (currentSpeed > 0)
            {
                rb2D.velocity = new Vector2(currentSpeed - RampDrag, rb2D.velocity.y);
            }
            else if (currentSpeed < 0)
            {
                rb2D.velocity = new Vector2(currentSpeed + RampDrag, rb2D.velocity.y);
            }
        }
        else
        {
            rb2D.velocity = new Vector2(currentSpeed, rb2D.velocity.y);
        }        

        if (stopping)
        {
            if (currentSpeed > 0)
            {
                currentSpeed = Mathf.Max(0, currentSpeed - decceleration*Time.deltaTime);
            }
            else if (currentSpeed < 0)
            {
                currentSpeed = Mathf.Min(0, currentSpeed + decceleration * Time.deltaTime);
            }
        }
        else
        {
            if (goingRight)
            {
                currentSpeed = Mathf.Min(maxSpeed, currentSpeed + acceleration*Time.deltaTime);
            }
            else
            {
                currentSpeed = Mathf.Max(-maxSpeed, currentSpeed - acceleration * Time.deltaTime);
            }
        }
    }

    public void OnMovement(InputValue val)
    {
        stopping = false;
        var AxisInput = val.Get<float>();
        if (AxisInput < 0)
        {
            goingRight = false;
           
        }
        else if (AxisInput > 0)
        {
            goingRight = true;
            
        }     
    }

    public void OnMovementEnd()
    {
        stopping = true;
        decceleration = Mathf.Abs(currentSpeed / deccelerationCoefficient);
    }
}
