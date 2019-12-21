using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositController : MonoBehaviour
{
    public float percentage = 100f;
    public float delay = 0f;
    private Vector3 startScale;
    public GameObject indicator;
    public float tiempoEnHoras = 0f;
    public float tiempoEnMinutos = 0f;
    public float tiempoEnSegundos = 10f;
    public float seconds = 0;
    public float secondsToCompare = 0;
    public float substractionPerSeconds = 0;
    public bool resetAll = false;

    private void Start()
    {
        startScale = indicator.transform.localScale;
        substractionPerSeconds = 100f / (tiempoEnHoras * 3600f + tiempoEnMinutos * 60f + tiempoEnSegundos);
        //Debug.Log("IN START "+ gameObject.name + " " + percentage);
    }
    private void Update()
    {

        seconds += Time.deltaTime;
        if (resetAll)
            ResetAll();
        if(percentage > 0f)
            Restador();

        if (percentage < 0f)
        {
            percentage = 0f;
        }

        if (percentage > 100f)
            percentage = 100f;

        indicator.transform.localScale = new Vector3(startScale.x, startScale.y -(startScale.y - percentage / 100f), startScale.z);
    }
    private void Restador()
    {
        if(seconds != secondsToCompare)
        {
            float diference = (seconds - secondsToCompare);
            
            percentage -= ((substractionPerSeconds * diference) - delay);
            secondsToCompare = seconds;
            delay = 0f;
            
        }
    }
    public void ResetAll()
    {
        percentage = 100f;
        delay = 0f;
        seconds = 0;
        secondsToCompare = 0;
        resetAll = false;
    }

    public void UpdateTime(float _percentage, float _substractionPerSeconds, int _day, int _month, int _year, int _hour, int _minute, int _second)
    {
        int day, month, year, hour, minute, second, secondsToSubstrate;

        ResetAll();

        percentage = _percentage;
        day = System.DateTime.Now.Day - _day;
        month = System.DateTime.Now.Month - _month;
        year = System.DateTime.Now.Year - _year;
        hour = System.DateTime.Now.Hour - _hour;
        minute = System.DateTime.Now.Minute - _minute;
        second = System.DateTime.Now.Second - _second;
        substractionPerSeconds = _substractionPerSeconds;

        //Debug.Log("Has estado: " + day + "/" + month + "/" + year + " y " + hour + ":" + minute + ":" + second + " sin jugar.");

        secondsToSubstrate = second + (minute * 60) + (hour * 3600) + (day * 3600 * 24); //No ponemos màs porque no es necesario

        percentage -= substractionPerSeconds * secondsToSubstrate;
        //Debug.Log("IN UPDATETIME " + gameObject.name + " secondstosubstrate " + secondsToSubstrate);
        //Debug.Log("IN UPDATETIME " + gameObject.name + " substractionpersecond " + substractionPerSeconds);
        //Debug.Log("IN UPDATETIME " + gameObject.name + " percentage " + percentage);
    }
}
