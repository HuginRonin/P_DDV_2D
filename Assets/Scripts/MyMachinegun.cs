using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMachinegun : Gun {

    private float lastShotTime = 0;
    public float ShootFrequency;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      if (Input.GetKey(KeyCode.Space)){
        TryFire();
        }
        
    }

    private void TryFire()
    {
        if(Time.time > lastShotTime + ShootFrequency)
        {
            Fire();
            lastShotTime = Time.time;
        }
    }
}
