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

    // this int is the cake health points. This is a different variable than playerHealth
    float maxCakeHealth = 100;
    //Cake's current health points
    float currentCakeHealth;

    // this boolean will help us keep track of weather the cake is on the ground or not/
    bool ground = true;

    // this allows us to display the variable cakeHealth on UI
    //[SerializeField] Text cakeHealthCounter;

    void Start()
    {
        currentCakeHealth = maxCakeHealth;
        cakeHealthBar.SetMaxCakeHealth(maxCakeHealth);
        myCake = this.transform;

    }

    // this event is triggered whenever the cake collider collides with another collider
    void OnCollisionEnter(Collision collisioninfo)
    {

        if (collisioninfo.collider.tag == "Player")
        {
            myCake.position = cakeHolder.position;
            myCake.parent = cakeHolder;

            myCake.transform.localRotation = Quaternion.Euler(0, 0, 0);
            cakeHolder.transform.localRotation = Quaternion.Euler(0, 0, 105);
            


            ground = false;
            Debug.Log("The Cake is Held!!");

        }

        if (collisioninfo.collider.tag == "Zombie")
        {
            TakeDamage(10);
        }


    }

    void TakeDamage(float damage)
    {
        currentCakeHealth -= damage;
        cakeHealthBar.SetCakeHealth(currentCakeHealth);
    }

    void GroundDamage(float damage)
    {
        currentCakeHealth = currentCakeHealth - damage * Time.deltaTime;
        cakeHealthBar.SetCakeHealth(currentCakeHealth);
    }


    // Update is called once per frame
    private void Update()
    {
        // this changes the variable playerHealthCounter with the updated cake health every frame
        //cakeHealthCounter.text = "Cake Hp: " + health;

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

    }

}

