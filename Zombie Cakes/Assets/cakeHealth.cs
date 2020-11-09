using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cakeHealth : MonoBehaviour
{
    // this int is the cake health points. This is a different variable than playerHealth
    int health = 100;

    // this allows us to display the variable cakeHealth on UI
    //[SerializeField] Text cakeHealthCounter;

    // this event is triggered whenever the cake collider collides with another collider
    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Zombie")
        {
            health = health - 10;
            Debug.Log(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // this changes the variable playerHealthCounter with the updated cake health every frame
        //cakeHealthCounter.text = "Cake Hp: " + health;

        // This methos will trigger game over when cake health drops to 0
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
