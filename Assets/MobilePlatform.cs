using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    public Transform P1;
    public Transform P2;

    [SerializeField]
    private float speed;

    private float currentPoint;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentPoint = 2;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = GetPosition();
    }

    private Vector2 GetPosition()
    {
        var pos = Vector3.Lerp(P1.position, P2.position, GetFraction());
        return new Vector2(pos.x, pos.y);
    }

    private float GetFraction()
    {
        return (Mathf.Sin(Time.time * speed) + 1) / 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<MovementController>();
        if (player)
        {
            player.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<MovementController>();
        if (player)
        {
            player.transform.SetParent(null);
        }
    }
}
