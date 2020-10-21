using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    int health = 100;

    private void Update()
    {
        if (health <= 0)
        {
            
            
        }

    }

    void OnCollisionEnter(Collision collisioninfo)
    {
       if(collisioninfo.collider.name == "Zombie")
        {
            health = health - 50;
            Debug.Log(health);
        }
    }
}