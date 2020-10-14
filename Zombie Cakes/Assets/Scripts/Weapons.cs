using System;


public class Weapons
{


    float wepRange = 100f;
    float fireRate = 15f;
    int wepDamage = 10;
    int maxAmmoCapacity = 0;
    float reloadTime = 1f;

    // default values for weapons
    public Weapons()
    {
        wepRange = 100f;
        fireRate = 15f;
    }

    // or creating new values for each new gun
    public Weapons(float newRange, float newFirerate, int newWepDamage, int newWepAmmoCapacity, float NewReloadTime)
    {

        wepRange = newRange;
        fireRate = newFirerate;
        wepDamage = newWepDamage;
        maxAmmoCapacity = newWepAmmoCapacity;
        reloadTime = NewReloadTime;

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

    public float GetWeaponDamage()
    {
        float myWepDamage = wepDamage;
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
