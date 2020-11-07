using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerAnimationController : MonoBehaviour
{

    public GameObject RightHand;
    public GameObject LeftHand;
    Animator rightHandAnimator;
    Animator leftHandAnimator;
    public playerAttack playerAttack;
    public PlayerMovement playerMove;

    // Start is called before the first frame update
    private void Start()
    {

        rightHandAnimator = RightHand.GetComponent<Animator>();

        leftHandAnimator = LeftHand.GetComponent<Animator>();

        Debug.Log("Right Hand Animator = " + rightHandAnimator.ToString());
        Debug.Log("Left Hand Animator = " + leftHandAnimator.ToString());

    }

    private void Update()
    {

        if (playerAttack.isReloading != true)
        {

            // Check to see if thr player has a big gun held or a pistol
            if (playerAttack.weaponSize == true)
            {
                rightHandAnimator.SetBool("Big Gun", true);
                leftHandAnimator.SetBool("Big Gun", true);

                rightHandAnimator.SetBool("Small Gun", false);
                leftHandAnimator.SetBool("Small Gun", false);
            }
            else
            if (playerAttack.weaponSize == false)
            {

                rightHandAnimator.SetBool("Small Gun", true);
                leftHandAnimator.SetBool("Small Gun", true);

                rightHandAnimator.SetBool("Big Gun", false);
                leftHandAnimator.SetBool("Big Gun", false);
            }

            // this if for the main animations
            if (rightHandAnimator.GetBool("isReloading").Equals(true))
            {
                rightHandAnimator.SetBool("isReloading", false);
                leftHandAnimator.SetBool("isReloading", false);

            }

            if (playerMove.isRunning == false && playerAttack.shoot == true)
            {
                rightHandAnimator.SetTrigger("isShooting");
                leftHandAnimator.SetTrigger("isShooting");
                // Debug.Log("Shooting Animation");
            }
            else
            if (playerMove.isRunning == true && playerAttack.shoot == true)
            {
                rightHandAnimator.SetTrigger("isShooting");
                leftHandAnimator.SetTrigger("isShooting");
                rightHandAnimator.SetBool("isWalking", false);
                // Debug.Log("Shooting Animation");
            }
            else
            if (playerMove.isRunning == true && playerAttack.shoot == false)
            {
                rightHandAnimator.SetTrigger("isRunning");
                rightHandAnimator.SetBool("isWalking", false);
                // Debug.Log("Shooting Animation");
            }
            else
            if (playerMove.isRunning == false && playerAttack.shoot == false)
            {
                rightHandAnimator.SetBool("isWalking", true);
                rightHandAnimator.SetTrigger("isIdle");


                leftHandAnimator.SetBool("isWalking", true);
                leftHandAnimator.SetTrigger("isIdle");
                // Debug.Log("Shooting Animation");
            }
        }
        else
        if (playerAttack.isReloading == true)
        {

            leftHandAnimator.SetBool("isReloading", true);
            leftHandAnimator.SetTrigger("Reload");

            rightHandAnimator.SetBool("isReloading", true);
            rightHandAnimator.SetTrigger("Reload");

            // Debug.Log("Shooting Animation");
        }

    }

}