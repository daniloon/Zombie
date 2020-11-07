using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWep = 0;
    public Weapons currentWeapon;

    // Start is called before the first frame update
    void Start()
    {

        SelectCurrentWeapon();


    }

    // Update is called once per frame
    void Update()
    {

        int prevWeapon = selectedWep;

        if (selectedWep > transform.childCount - 1)
        {
            selectedWep = 0;
        }
        else
        if (selectedWep < 0)
        {
            selectedWep = transform.childCount - 1;
        }

        if (prevWeapon != selectedWep)
        {
            SelectCurrentWeapon();
        }

    }

    public void SelectCurrentWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {

            if (i == selectedWep)
            {
                weapon.gameObject.SetActive(true);
                currentWeapon = weapon.GetComponent<Weapons>();
            }
            else
            {
                weapon.gameObject.SetActive(false);

            }
            i++;

        }

    }
}
