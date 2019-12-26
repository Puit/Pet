using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LightBulbController : MonoBehaviour
{
    Image myImage;
    public Sprite ON, OFF;

    public Image lightFilter;

    public bool lights;
    public CobiController cobi;
    

    private GameObject cobiSleeping;
    public GameObject cobiObject; //just the image, so the CobiController can still work
    //public GameObject prefabSleeping;

    public void Start()
    {
        //Debug.Log("Before");
        myImage = GetComponentInParent<Image>();
        //lightFilter = GameObject.FindGameObjectWithTag("SleepFilter");
        lightFilter = GameObject.Find("SleepFilter").GetComponent<Image>();

        cobi = FindObjectOfType<CobiController>();
        //cobiObject = GameObject.FindWithTag("Player").transform.Find("Body").gameObject;
        cobiObject = GameObject.Find("Cobi").transform.Find("Body").gameObject;
        cobiSleeping = GameObject.Find("CobiSleeping").transform.Find("Body").gameObject;
        //cobi = cobiObject.GetComponent<CobiController>();

        TurnLightsOn();
        Debug.Log("After");

    }
    private void TurnLightsOn()
    {
        
        myImage.sprite = ON;
        lightFilter.enabled = false;
        lights = true;
        cobi.SleepingOff();

        cobiObject.SetActive(true);
        if (cobiSleeping)
        {
            //Destroy(cobiSleeping);
            cobiSleeping.SetActive(false);
        }
        //cobiSleeping.SetActive(false);
    }
    private void TurnLightsOff()
    {
        
        myImage.sprite = OFF;
        //lightFilter.SetActive(true);
        lightFilter.enabled = true;
        lights = false;
        cobi.SleepingOn();

        cobiObject.SetActive(false);
        cobiSleeping.SetActive(true);


    }
    public void ChangeLights()
    {
        if (lights)
            TurnLightsOff();
        else
            TurnLightsOn();
    }
}
