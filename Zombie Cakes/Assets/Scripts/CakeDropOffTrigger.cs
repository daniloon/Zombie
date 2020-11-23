using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeDropOffTrigger : MonoBehaviour
{

    GameObject theCake;

    // Start is called before the first frame update
    void Start()
    {
        theCake = GameObject.FindGameObjectWithTag("Cake");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Cake")
        {
            Destroy(theCake);
            Debug.Log("You dropped off the Cake!");
        }

    }


}



