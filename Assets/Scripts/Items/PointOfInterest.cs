using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    public Camera cam;
    CameraTarget camScript;
    private Rigidbody2D rb2D;
    private Transform pos;
    // Start is called before the first frame update
    void OnEnable()
    {
        cam = Camera.main;
        camScript = cam.GetComponent<CameraTarget>();
        rb2D = GetComponent<Rigidbody2D>();
        pos = rb2D.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("deacuerdo");
            camScript.Targets.Add(pos);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camScript.Targets.Remove(pos);
        }
    }
}
