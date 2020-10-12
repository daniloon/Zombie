using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{

    // This is to access the game controller

    // Zombie values
    float health = 20;
    int scoreValue = 100;
    public bool canMove = true;
    public bool wasShot = false;

    // AI setup
    NavMeshAgent navAgent;
    GameObject myTarget;
    public GameObject myCorpse;
    Animator zombieAnimator;

    int tick = 0;


    // Start is called before the first frame update
    void Start()
    {

        navAgent = GetComponent<NavMeshAgent>();
        myTarget = GameObject.FindGameObjectWithTag("Player");

        zombieAnimator = this.GetComponent<Animator>();

    }

    public void TakeDamage(float damageAmount)
    {

        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        canMove = false;

        zombieAnimator.SetTrigger("Shot");
        health -= damageAmount;
        //Debug.Log("I Cant Move!");

        if (health <= 0)
        {
          Die();
        }

    }

    void Die()
    {

        Instantiate(myCorpse, this.transform.position, this.transform.rotation);
        Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {

        //if the zombie can move, then we make it move.
        if (canMove == true)
        {
            navAgent.SetDestination(myTarget.transform.position);
        }



        // if the zombie is not currently able to move, then we fix that issue and get him moving again.
        if (wasShot == true)
        {

            tick++;

            if (tick > 32 && zombieAnimator.GetCurrentAnimatorStateInfo(0).IsTag("isRunning"))
            {

                wasShot = false;
                canMove = true;
                //Debug.Log("I Can Move Again!");
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;

            }

        }

    }

}
