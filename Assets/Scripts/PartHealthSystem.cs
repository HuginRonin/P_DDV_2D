using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartHealthSystem : MonoBehaviour, IDamageTaker
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void TakeDamage(float amount)
    {
        Debug.Log("That's a lot of damage: " + amount);
        currentHealth = currentHealth -= amount;
    }
}
