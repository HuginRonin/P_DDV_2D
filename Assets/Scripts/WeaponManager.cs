using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> equippedWeapons;
    private Weapon currentW;
    public Transform weaponPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(0);
        }
    else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(1);
        }
    }

    void SwapWeapon(int type)
    {
        DestroyWeapon();
        AddNew(type);
    }

    void AddNew(int type)
    {
        currentW = Instantiate(equippedWeapons[type], weaponPoint.position,weaponPoint.rotation).GetComponent<Weapon>();
        currentW.transform.SetParent(transform);
    }

    void DestroyWeapon()
    {
        if (currentW)
        {
            Destroy(currentW.gameObject);
        }
    }
}
