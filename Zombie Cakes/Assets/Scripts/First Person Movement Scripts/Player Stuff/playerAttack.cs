using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class playerAttack : MonoBehaviour
{




    public bool shoot = false;
    public bool isReloading = false;
    public Camera playerCam;
    Weapons pistol = new Weapons(100f, 6f, 10, 16, 1f);
    int currentAmmo = 0;
    private float nextTimeToFire = 0;

    [SerializeField] Text ammoCounter;


    // Start is called before the first frame update
    void Start()
    {

        currentAmmo = pistol.GetWeaponAmmoCapacity();

    }




    void Shoot()
    {
        
        currentAmmo--;

        RaycastHit thisHit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out thisHit, pistol.GetWeaponRange()))
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
                    myTarget.TakeDamage(pistol.GetWeaponDamage());
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
            Debug.Log("Reloading!");

            yield return new WaitForSeconds(pistol.GetWeaponReloadTime() + 0.75f);

            currentAmmo = pistol.GetWeaponAmmoCapacity();
            isReloading = false;
        }

    }

    private void Update()
    {

        // this is to display the current bullets in the UI
        ammoCounter.text = currentAmmo.ToString() + " / " + pistol.GetWeaponAmmoCapacity().ToString();


        // This is for shooting
        if (Input.GetButtonDown("Fire1"))
        {

            if (currentAmmo > 0 && Time.time >= nextTimeToFire) {

                nextTimeToFire = Time.time + 1f / pistol.GetWeaponFireRate();
                shoot = true;
                //Debug.Log("Shoot is True");
                Shoot();

            }

        }

        // this is for reloading
        if (Input.GetButtonDown("Reload"))
        {
            isReloading = true;
            StartCoroutine(Reload());
        }



        if (shoot != false)
        {
            shoot = false;
            //Debug.Log("Shoot is False");
        }


    }

}
