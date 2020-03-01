using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : Gun
{
    private PlayerDetection detect;
    private float lastShotTime = 0;
    public float ShootFrequency;
    // Start is called before the first frame update
    void Start()
    {
        detect = GetComponent<PlayerDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detect.PlayersDetected.Length > 0 && Time.time > lastShotTime + ShootFrequency)
        {
            lastShotTime = Time.time;
            Fire();            
        }
    }

    protected override void Fire()
    {
        GameObject rocket = ObjectPooler.GetPooledObject(projectile.name);
        if (rocket)
        {
            Debug.Log("lanzado");
            rocket.transform.position = firePoint.position;
            rocket.transform.rotation = firePoint.rotation;
            rocket.SetActive(true);
            rocket.GetComponent<DamageDealer>().target = target;

            rocket.GetComponent<Rocket>().enabled = true;
            
        }
    }
}
