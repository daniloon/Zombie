using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class playerAttack : MonoBehaviour
{

    public Weapons currentGun;
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
    public int myCurrentMaxAmmo;
    int myCurrentAmmo;
    public bool weaponSize = false;

    [SerializeField] Text ammoCounter;


    // Start is called before the first frame update
    void Start()
    {
        myMovement = GetComponentInParent<PlayerMovement>();

        currentGun = weaponHolder.GetComponent<WeaponSwitching>().currentWeapon;
        myCurrentAmmo = currentGun.currentAmmo;
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
            myCurrentMaxAmmo = currentGun.currentMaxAmmo;
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

            Debug.Log(myCurrentMaxAmmo);
            yield return new WaitForSeconds(myReloadTime + 0.7f);

                
                var newNum = myMaxAmmo - myCurrentAmmo;

            if (myCurrentAmmo + myCurrentMaxAmmo >= myMaxAmmo)
            {
                myCurrentAmmo = myMaxAmmo;
            }
            else
            {
                myCurrentAmmo += myCurrentMaxAmmo;
            }


                currentGun.currentAmmo = myCurrentAmmo;
                Debug.Log(newNum);

                myCurrentMaxAmmo = myCurrentMaxAmmo - newNum;

                if (myCurrentMaxAmmo >= 0) { currentGun.currentMaxAmmo = myCurrentMaxAmmo; }
                else
                { currentGun.currentMaxAmmo = 0; }


                Debug.Log("Current Max Ammo is: " + myCurrentMaxAmmo.ToString());

                isReloading = false;

            

        }

    }

    private void Update()
    {

        // this is to display the current bullets in the UI

        if (currentGun != null)
        {
            ammoCounter.text = myCurrentAmmo.ToString() + " / " + currentGun.currentMaxAmmo.ToString();
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
        if (canReload == true && Input.GetButtonDown("Reload") &&  myCurrentMaxAmmo != 0)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }

        // this is to continuosly update the currently equipped weapon.
        UpdateWeapon();


        // This will be to switch weapons
        if (isReloading == false)
        {
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
            else
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

        } // end of is reloading


    }

}
