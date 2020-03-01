using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed;
    GameObject[] possibleTargets;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    private void OnEnable()
    {
        target = transform;
        rb2D = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        SetVelocity();
        possibleTargets = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < possibleTargets.Length; i++)
        {
            if (possibleTargets[i].GetComponent<Leg>() != null)
            {
                target = possibleTargets[i].transform;
            }
        }

        target = possibleTargets[0].transform;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetVelocity();
    }

    private void FixedUpdate()
    {

    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void SetVelocity()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        targetRotation.x = 0;
        targetRotation.y = 0;
        spr.transform.rotation = targetRotation;
        rb2D.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
