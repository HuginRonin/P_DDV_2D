using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHealthSystem : MonoBehaviour
{
    public delegate void OnDeathDelegate(PlayerInfo playerInfo);
    public static OnDeathDelegate OnDeath;

    private PlayerInfo pInfo;
    List<BodyPart> parts;

    public float currentHealth => GetGlobalHealth();
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
        return 0;
    }

    void Die()
    {
        OnDeath?.Invoke(pInfo);
        dead = true;
    }
}
