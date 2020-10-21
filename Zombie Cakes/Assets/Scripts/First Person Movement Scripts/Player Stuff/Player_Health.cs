using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    int health = 100;

    [SerializeField] Text playerHealthCounter;

    void OnCollisionEnter(Collision collisioninfo)
    {
       if(collisioninfo.collider.name == "Zombie")
        {
            health = health - 50;
            Debug.Log(health);
        }
    }



    private void Update()
    {

        playerHealthCounter.text = "HP: " + health;

        if (health <= 0)
        {


        }

    }




}