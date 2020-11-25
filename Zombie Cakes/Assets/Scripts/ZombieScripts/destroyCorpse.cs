using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCorpse : MonoBehaviour
{
    Animator myAnimator;
    gameController myGameController;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        GameObject thisGameController = GameObject.FindGameObjectWithTag("Game Controller");
        myGameController = thisGameController.GetComponent<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Destroy"))
        {
            myGameController.currentZombieCount -= 1;
            Destroy(gameObject);
            Destroy(this);
            Debug.Log("Corpse Destroyed Successfully");
        }
        else
        if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Corpse Animation") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Destroy"))
        {
            Debug.Log("Error in deleting corpse!");
        }
    }

}
