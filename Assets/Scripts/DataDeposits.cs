using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataDeposits
{
    public static DataDeposits current;
    public int day, month, year, hour, minute, second;
    public float depHealth, depFood, depWC, depPlay, depSleep, depLovis, depWater;
    public float SPSHealth, SPSFood, SPSWC, SPSPlay, SPSSleep, SPSLovis, SPSWater;

    public DataDeposits(int _day, int _month, int _year, int _hour, int _minute, int _second,
        float _depHealth, float _depFood, float _depWC, float _depPlay, float _depSleep, float _depLovis, float _depWater,
        float _SPSHealth, float _SPSFood, float _SPSWC, float _SPSPlay, float _SPSSleep, float _SPSLovis, float _SPSWater)
    {
        day = _day;
        month = _month; 
        year = _year; 
        hour = _hour;
        minute = _minute; 
        second = _second;

        depHealth = _depHealth;
        depFood = _depFood;
        depWC = _depWC;
        depPlay = _depPlay;
        depSleep = _depSleep;
        depLovis = _depLovis;
        depWater = _depWater;

        SPSHealth = _SPSHealth;
        SPSFood = _SPSFood;
        SPSWC = _SPSWC;
        SPSPlay = _SPSPlay;
        SPSSleep = _SPSSleep;
        SPSLovis = _SPSLovis;
        SPSWater = _SPSWater;
    }
}
