using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter(Collision collisioninfo)
    {

        if (collisioninfo.collider.tag == "Zombie")
        {
            TakeDamage(10);
            //uniDebug.Log(health);
        }
    }

    //Calculates the damage player should take
    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }
}
