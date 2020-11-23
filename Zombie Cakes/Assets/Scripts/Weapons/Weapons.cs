using System;
using UnityEngine;

public class Weapons : MonoBehaviour
{


    public float wepRange = 100f;
    public float fireRate = 15f;
    public int wepDamage = 10;
    public int maxAmmoCapacity = 0;
    public int currentMaxAmmo = 0;
    public int currentAmmo = 0;
    public float reloadTime = 1f;
    public bool bigGun = false;


    private void Start()
    {
        currentMaxAmmo = maxAmmoCapacity;
    }

    public float GetWeaponRange()
    {
        float myRange = wepRange;
        return myRange;

    }

    public float GetWeaponFireRate()
    {
        float myFireRate = fireRate;
        return myFireRate;

    }

    public int GetWeaponDamage()
    {
        int myWepDamage = wepDamage;
        return myWepDamage;

    }

    public int GetWeaponAmmoCapacity()
    {
        int myWepCapacity = maxAmmoCapacity;
        return myWepCapacity;

    }

    public float GetWeaponReloadTime()
    {
        float myReloadTime = reloadTime;
        return myReloadTime;

    }

}

