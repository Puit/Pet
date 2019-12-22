using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBulbController : MonoBehaviour
{
    Image myImage;
    public Sprite ON, OFF;

    public Image lightFilter;

    public bool lights;
    private CobiController cobi;

    public void Start()
    {
        Debug.Log("Before");
        myImage = GetComponentInParent<Image>();
        //lightFilter = GameObject.FindGameObjectWithTag("SleepFilter");
        lightFilter = GameObject.Find("SleepFilter").GetComponent<Image>();
        TurnLightsOn();
        cobi = FindObjectOfType<CobiController>();
        
        Debug.Log("After");

    }
    private void Update()
    {
        //if (lightFilter.activeSelf && !lights)
        //{
        //    TurnLightsOn();
        //}
        //lightFilter = GameObject.Find("SleepFilter");
    }
    private void TurnLightsOn()
    {
        
        myImage.sprite = ON;
        //lightFilter.SetActive(false);
        lightFilter.enabled = false;
        lights = true;
        cobi.SleepingOn();
    }
    private void TurnLightsOff()
    {
        
        myImage.sprite = OFF;
        //lightFilter.SetActive(true);
        lightFilter.enabled = true;
        lights = false;
        cobi.SleepingOn();
    }
    public void ChangeLights()
    {
        if (lights)
            TurnLightsOff();
        else
            TurnLightsOn();
    }
}
