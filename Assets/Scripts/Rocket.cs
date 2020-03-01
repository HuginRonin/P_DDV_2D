using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D rb2D;
    public Transform target;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    private void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
        SetVelocity();
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
        rb2D.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
