using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRecord : MonoBehaviour
{
    private void OnEnable()
    {
        HealthSystem.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        HealthSystem.OnDeath -= OnDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnDeath(PlayerInfo playerInfo)
    {
        Debug.Log("se ha matao " + playerInfo.name);
    }
}
