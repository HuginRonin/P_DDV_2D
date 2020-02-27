using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalHealthSystem : MonoBehaviour
{
    public delegate void OnDeathDelegate(PlayerInfo playerInfo);
    public static OnDeathDelegate OnDeath;

    private PlayerInfo pInfo;
    BodyPart[] parts;

    List<Leg> legs => parts.OfType<Leg>().ToList();

    public float maxHealth;
    public float currentHealth => GetGlobalHealth();
    private bool dead = false;

    public float SpeedModifier => GetSpeedModifier();

    private float GetSpeedModifier()
    {
        float healthFraction = 0;
        for(int i = 0; i <legs.Count; i++)
        {
            healthFraction += legs[i].HealthFraction;
                   
        }
        var avg = healthFraction / legs.Count;  
        return avg;
    }

    // Start is called before the first frame update
    void Start()
    {
        parts = GetComponentsInChildren<BodyPart>();
    }

    private void Update()
    {
        
    }

    public void BodyPartHit()
    {
        if(GetGlobalHealth() <= 0 && !dead)
        {
            Die();
        }
    }

    private float GetGlobalHealth()
    {
        float missingHealth = 0;
        for (int i = 0; i < parts.Length; i++)
        {
            missingHealth += parts[i].HealthContribution;
        }

        return maxHealth - missingHealth;
    }

    void Die()
    {
        OnDeath?.Invoke(pInfo);
        dead = true;
    }
}
