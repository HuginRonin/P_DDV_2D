using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    [SerializeField]
    private float maxHealth;
   
    private float currentHealth;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    private bool dead;
    public delegate void OnDeathDelegate(PlayerInfo playerInfo);
    public static OnDeathDelegate OnDeath;

    public PlayerInfo pInfo;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
       
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("That's a lot of damage: " + amount);
        //float realDamage = amount - defense;
        currentHealth = currentHealth -= amount;

        if(currentHealth <= 0 && !dead)
        {
            Die();
        }

        BroadcastMessage("OnHit");
    }

    void Die()
    {
        OnDeath?.Invoke(pInfo);
        dead = true;

        gameObject.SetActive(false);
    }
}
