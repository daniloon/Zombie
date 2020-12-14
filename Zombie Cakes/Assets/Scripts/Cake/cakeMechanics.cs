using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cakeMechanics : MonoBehaviour
{

    Transform myCake;
    public Transform cakeHolder;
    public CakeHealthBar cakeHealthBar;
    public playerAttack playerAtt;
    public PlayerMovement playerMove;

    // this is the rigidbody that gives the cake physics
    public Rigidbody rb;

    // this int is the cake health points. This is a different variable than playerHealth
    float maxCakeHealth = 100;
    //Cake's current health points
    float currentCakeHealth;

    // this boolean will help us keep track of weather the cake is on the ground or not/
    bool ground = false;


    void Start()
    {
        currentCakeHealth = maxCakeHealth;
        cakeHealthBar.SetMaxCakeHealth(maxCakeHealth);
        myCake = this.transform;

        rb = GetComponent<Rigidbody>();

    }

    // this event is triggered whenever the cake collider collides with another collider
    void OnCollisionEnter(Collision collisioninfo)
    {
        // handles player collision
        if (collisioninfo.collider.tag == "Player")
        {
            // this code allows for cake pick-up
            myCake.position = cakeHolder.position;
            myCake.parent = cakeHolder;

            // this code sets the rotation of the cake on the player hand after pick-up
            myCake.transform.localRotation = Quaternion.Euler(0, 0, 0);
            cakeHolder.transform.localRotation = Quaternion.Euler(0, 0, 105);
            
            // change cake ground status after pick-up
            ground = false;
            //Debug.Log("The Cake is Held!!");

            // this method will disable cake physics
            DisablePhysics();

        }

        // handles zombie collision
        if (collisioninfo.collider.tag == "Zombie")
        {
            TakeDamage(10);
        }



    }


    public void TakeDamage(float damage)
    {
        currentCakeHealth -= damage;
        cakeHealthBar.SetCakeHealth(currentCakeHealth);
    }

    void GroundDamage(float damage)
    {
        currentCakeHealth = currentCakeHealth - damage * Time.deltaTime;
        cakeHealthBar.SetCakeHealth(currentCakeHealth);
    }

    // enables cake physics
    void EnablePhysics()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    // disables cake physics
    void DisablePhysics()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }


    // Update is called once per frame
    private void Update()
    {

        // this method will trigger game over when cake health drops to 0
        if (currentCakeHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }

        // when the cake is on the ground it will slowly lose health
        if (ground)
        {
            GroundDamage(1);
            //Debug.Log(cakeHealthBar);

        }

        // handles dropping the cake
        if (ground == false && Input.GetKeyDown(KeyCode.E))
        {
            // this code will allow for the cake to be dropped by the player
            myCake.parent = null;
            playerMove.cakeHeld = false;
            // change cake ground status after dropping it
            ground = true;

            // this method will enable the cake physics so that it can fall to the ground
            EnablePhysics();
        }

    }

}

