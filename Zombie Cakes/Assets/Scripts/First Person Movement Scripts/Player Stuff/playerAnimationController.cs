using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerAnimationController : MonoBehaviour
{


    public Animator rightHandAnimator;
    public Animator leftHandAnimator;
    public playerAttack playerAttack;
    public PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {

        rightHandAnimator = GetComponent<Animator>();

        leftHandAnimator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (playerAttack.isReloading == false)
        {

            if (rightHandAnimator.GetBool("isReloading").Equals(true))
            {
                rightHandAnimator.SetBool("isReloading", false);
                leftHandAnimator.SetBool("isReloading", false);

            }

            if (playerMove.isRunning == false && playerAttack.shoot == true)
            {
                rightHandAnimator.SetTrigger("isShooting");
                // Debug.Log("Shooting Animation");
            }
            else
            if (playerMove.isRunning == true && playerAttack.shoot == true)
            {
                rightHandAnimator.SetTrigger("isShooting");
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
