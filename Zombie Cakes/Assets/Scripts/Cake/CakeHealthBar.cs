using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CakeHealthBar : MonoBehaviour
{
    //Slider for moving the health bar down
    public Slider slider;

    //Sets the slider to the max health of the cake
    public void SetMaxCakeHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //Sets the slider to equal the current cake health
    public void SetCakeHealth(float health)
    {
        slider.value = health;
    }

}
