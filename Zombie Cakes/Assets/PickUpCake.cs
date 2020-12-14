using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCake : MonoBehaviour { 

    public GameObject cakePrefab;
    public int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // handles the event of the cake having been delivered
        if (GameObject.Find("Cake") == null)
        {
            // decide on store to spawn cake (random number between 1 and 3)
            randomNumber = Random.Range(1, 4);

            if (randomNumber == 1)
            {
                Instantiate(cakePrefab, new Vector3(1035, 13, 94), Quaternion.identity);
            } 
            else if (randomNumber == 2)
            {
                Instantiate(cakePrefab, new Vector3(1234, 13, 998), Quaternion.identity);
            } 
            else
            {
                Instantiate(cakePrefab, new Vector3(167, 13 , 127), Quaternion.identity);
            }
            
        }
    }
}
