using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawning : MonoBehaviour
{
    public Camera cam;
    CameraTarget camScript;
    private Rigidbody2D rb2D;
    private Transform pos;
    private PlayerInput input;
    public InputDevice dev;

    private void OnEnable()
    {
        cam = Camera.main;
        camScript = cam.GetComponent<CameraTarget>();
        rb2D = GetComponent<Rigidbody2D>();
        pos = rb2D.transform;
        camScript.Targets.Add(pos);

        if(Gamepad.current!= null)
        {
            dev = Gamepad.current;
            input.SwitchCurrentControlScheme(dev);
        }
        else
        {
            dev = Keyboard.current;
            input.SwitchCurrentControlScheme(dev);
        }


        Vector3 spawnPoint = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

        transform.position = spawnPoint;
    }

    private void OnDisable()
    {
        camScript.Targets.Remove(pos);
    }
}
