using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxUse : MonoBehaviour
{

    playerAttack playerAtt;

    private void Start()
    {
        playerAtt = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<playerAttack>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" && playerAtt.myCurrentMaxAmmo < playerAtt.currentGun.maxAmmoCapacity)
        {
            Destroy(gameObject);
        }
    }

}
