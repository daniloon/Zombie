using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCake : MonoBehaviour { 

    public GameObject cakePrefab;
    public cakeMechanics thisCake;
    public int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        // handles the event of the cake having been delivered
        if (GameObject.FindGameObjectWithTag("Cake") == null)
        {
            // decide on store to spawn cake (random number between 1 and 3)
            randomNumber = Random.Range(1, 4);

            if (randomNumber == 1)
            {

                var i = Instantiate(cakePrefab, new Vector3(1035, 13, 94), Quaternion.identity);
                thisCake = i.GetComponent<cakeMechanics>();

                thisCake.cakeHolder = GameObject.Find("LeftCakeHolder").GetComponent<Transform>();
                thisCake.cakeHealthBar = GameObject.Find("CakeBar").GetComponent<CakeHealthBar>();
                thisCake.playerAtt = GameObject.Find("RightPlayerArm").GetComponent<playerAttack>();
                thisCake.playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();

            } 
            else if (randomNumber == 2)
            {

                var i = Instantiate(cakePrefab, new Vector3(1234, 13, 998), Quaternion.identity);
                thisCake = i.GetComponent<cakeMechanics>();

                thisCake.cakeHolder = GameObject.Find("LeftCakeHolder").GetComponent<Transform>();
                thisCake.cakeHealthBar = GameObject.Find("CakeBar").GetComponent<CakeHealthBar>();
                thisCake.playerAtt = GameObject.Find("RightPlayerArm").GetComponent<playerAttack>();
                thisCake.playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();

            } 
            else
            {

                var i = Instantiate(cakePrefab, new Vector3(167, 13 , 127), Quaternion.identity);
                thisCake = i.GetComponent<cakeMechanics>();

                thisCake.cakeHolder = GameObject.Find("LeftCakeHolder").GetComponent<Transform>();
                thisCake.cakeHealthBar = GameObject.Find("CakeBar").GetComponent<CakeHealthBar>();
                thisCake.playerAtt = GameObject.Find("RightPlayerArm").GetComponent<playerAttack>();
                thisCake.playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();

            }
            
        }
    }
}
