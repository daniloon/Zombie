using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CakeWaypoint : MonoBehaviour
{
    public Image wayImg;
    public Text distanceText;
    private Vector3 scaleChange, positionChange;
    public Transform player;
    public Transform target;
    public Camera cam;
    //public PlayerMovement holding;

    private void Start()
    {
        wayImg = GetComponent<Image>();
        distanceText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    private void Update()
    {

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Cake").GetComponent<Transform>();
        }
        

        wayImg.transform.localScale += scaleChange;
        wayImg.transform.position += positionChange;
        if (target != null)
        {
            GetDistance();
            CheckOnScreen();
        }
    }

    private void GetDistance()
    {
        float dist = Vector3.Distance(player.position, target.position);
        distanceText.text = dist.ToString("f1") + " ft";

        //if ()
        //{
        //    Desroy(gameObject);
        //}
    }

    private void CheckOnScreen()
    {
        float thing = Vector3.Dot((target.position - cam.transform.position).normalized, cam.transform.forward);

        if (thing <= 0)
        {
            ToggleUI(false);
        }
        else
        {
            ToggleUI(true);
            transform.position = cam.WorldToScreenPoint(target.position);
        }
    }

    private void ToggleUI(bool _value)
    {
        wayImg.enabled = _value;
        distanceText.enabled = _value;

    }
}
