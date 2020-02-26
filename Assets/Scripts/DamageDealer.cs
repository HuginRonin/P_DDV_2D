using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float dmgAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<IDamageTaker>();
        if (health != null)
        {
            health.TakeDamage(dmgAmount);
        }
    }
}
