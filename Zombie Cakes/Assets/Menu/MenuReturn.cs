﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuReturn : MonoBehaviour
{
    public void ReturnMenu()
    {
        GetComponent<Animation>();
        SceneManager.LoadScene(0);
        
    }

    
}
