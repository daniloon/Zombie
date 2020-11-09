using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cakeMechanics : MonoBehaviour
{
    // this int is the cake health points. This is a different variable than playerHealth
    int cakeHealth = 100;

    // this boolean will help us keep track of weather the cake is on the ground or not/
    bool ground = true;

    // this allows us to display the variable cakeHealth on UI
    //[SerializeField] Text cakeHealthCounter;

    // this event is triggered whenever the cake collider collides with another collider
    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Zombie")
        {
            cakeHealth = cakeHealth - 10;
            Debug.Log(cakeHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // this changes the variable playerHealthCounter with the updated cake health every frame
        //cakeHealthCounter.text = "Cake Hp: " + health;

        // this method will trigger game over when cake health drops to 0
        if (cakeHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }

        // TODO: fix this method. Right now this will crash the game. We need to figure out how to have the cake clowly lose health without crashing the game.
        // when the cake is on the ground it will slowly lose health
        /**
        while (ground)
        {
            cakeHealth = cakeHealth - (1 / 60);
            Debug.Log(cakeHealth);
        }
        **/
    }
}
