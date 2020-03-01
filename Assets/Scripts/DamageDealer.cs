using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float dmgAmount;
    public LayerMask target;
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
        if (1 << collision.gameObject.layer == target.value)
        { 
            var health = collision.GetComponent<IDamageTaker>();
            if (health != null)
            {
                Debug.Log("ting");
                health.TakeDamage(dmgAmount);
            }
        }
    }
}
