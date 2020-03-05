using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVisualizer : MonoBehaviour
{
    public HealthBar healthB;
    public HealthSystem healthSystem;

    private void Start()
    {
        OnHit();
    }

    private void OnHit()
    {
        healthB.SetValue(healthSystem.CurrentHealth/healthSystem.MaxHealth);
    }
}
