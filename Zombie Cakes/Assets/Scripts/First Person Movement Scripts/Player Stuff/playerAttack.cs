using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class playerAttack : MonoBehaviour
{

    private Weapons currentGun;
    public WeaponSwitching weaponHolder;
    public Camera playerCam;

    PlayerMovement myMovement;

    public bool shoot = false;
    public bool canReload = true;
    public bool isReloading = false;
    public float impactForce = 15f;
    private float nextTimeToFire = 0;
    float myWepRange;
    float myFireRate;
    float myReloadTime;
    int myWepDamage;
    int myMaxAmmo;
    int myCurrentAmmo;
    public bool weaponSize = false;

    [SerializeField] Text ammoCounter;


    // Start is called before the first frame update
    void Start()
    {
        myMovement = GetComponentInParent<PlayerMovement>();

        currentGun = weaponHolder.GetComponent<WeaponSwitching>().currentWeapon;

        UpdateWeapon();

    }


    // this is to update the current weapon;
    private void UpdateWeapon()
    {
        currentGun = weaponHolder.GetComponent<WeaponSwitching>().currentWeapon;

        if (currentGun != null)
        {
            myWepRange = currentGun.wepRange;
            myFireRate = currentGun.fireRate;
            myReloadTime = currentGun.reloadTime;
            myWepDamage = currentGun.wepDamage;
            myMaxAmmo = currentGun.maxAmmoCapacity;
            myCurrentAmmo = currentGun.currentAmmo;
            weaponSize = currentGun.bigGun;
        }
        else
        if (currentGun == null)
        {
            Debug.Log("No Weapon is Attached!");
        }

    }

    void Shoot()
    {

        myCurrentAmmo--;
        currentGun.currentAmmo = myCurrentAmmo;
        
        RaycastHit thisHit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out thisHit, myWepRange))
        {

            //Debug.Log(thisHit.transform.name);
            ZombieAI myTarget = thisHit.transform.GetComponent<ZombieAI>();

            //ZombieAI myTargetHead = thisHit.transform.GetComponentInParent<ZombieAI>();

            if (myTarget != null)
            {
                // This is for headshots. If we choose, we can implement this later

                //if (thisHit.transform.tag == "Head Collider")
                //{
                //    myTargetHead.HeadshotDie();
                //    myTargetHead.headshot = true;
                //    Debug.Log("Headshot!");

                //    if (myTargetHead.impactEffect != null)
                //    {
                //        GameObject zombieHitEffect = Instantiate(myTargetHead.impactEffect, thisHit.point, Quaternion.LookRotation(thisHit.normal));
                //        Destroy(zombieHitEffect, 0.75f);
                //    }

                //}
                //else
                if (thisHit.transform.tag != "Head Collider")
                {
                    myTarget.TakeDamage(myWepDamage);
                    myTarget.wasShot = true;
                    myTarget.canMove = false;
                    Debug.Log("Hit!");

                    // This is incase we want to do a blood effect or something.
                    
                    //if (myTarget.impactEffect != null)
                    //{
                    //    GameObject zombieHitEffect = Instantiate(myTarget.impactEffect, thisHit.point, Quaternion.LookRotation(thisHit.normal));
                    //    Destroy(zombieHitEffect, 0.75f);
                    //}

                } // end of if else if statement.

            } // end of the check for a valid target

        } // end of raycast

    } // End of shooting animation

    IEnumerator Reload()
    {

        if (isReloading == true)
        {

            yield return new WaitForSeconds(myReloadTime + 0.7f);

            currentGun.currentAmmo = currentGun.maxAmmoCapacity;
            myCurrentAmmo = myMaxAmmo;

            isReloading = false;
        }

    }

    private void Update()
    {

        // this is to display the current bullets in the UI

        if (currentGun != null)
        {
            ammoCounter.text = myCurrentAmmo.ToString() + " / " + currentGun.maxAmmoCapacity.ToString();
        }

        // This is for shooting
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {

            if (myCurrentAmmo > 0)
            {
                nextTimeToFire = Time.time + 1f / myFireRate;
                //Debug.Log("Shoot is True");
                Shoot();
                shoot = true;
            }

        }
        else
        {
            shoot = false;
        }

        // this is for reloading
        if (canReload == true && Input.GetButtonDown("Reload") && myCurrentAmmo < myMaxAmmo)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }

        // this is to continuosly update the currently equipped weapon.
        UpdateWeapon();


        // This will be to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponHolder.selectedWep = 0;
            weaponHolder.SelectCurrentWeapon();
        }

        // This will be to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponHolder.selectedWep = 1;
            weaponHolder.SelectCurrentWeapon();
        }

        // This will be to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponHolder.selectedWep = 2;
            weaponHolder.SelectCurrentWeapon();
        }


        // This will be to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponHolder.selectedWep = 3;
            weaponHolder.SelectCurrentWeapon();
        }


        if (myMovement.cakeHeld == true)
        {

            weaponHolder.selectedWep = 3;
            weaponHolder.SelectCurrentWeapon();
            canReload = false;

        }
        else
        {
            canReload = true;
        }

    }

}
