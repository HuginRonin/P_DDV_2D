using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject muzzlePrefab;
    public LayerMask target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    protected void Fire()
    {
        GameObject bullet = ObjectPooler.GetPooledObject("Bullet");
        if (bullet)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<DamageDealer>().target = target;
        }
        //ShowEffects();
    }

    private void ShowEffects()
    {
        Instantiate(muzzlePrefab, firePoint.position, firePoint.rotation);
    }
}
