using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCorpse : MonoBehaviour
{
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("End Me"))
        {
            Destroy(gameObject);
            Destroy(this);
        }
        else
        {
            Debug.Log("Error in deleting corpse!");
        }
    }

}
