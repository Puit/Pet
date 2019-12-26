using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SceneController : MonoBehaviour
{
    public int day, month, year, hour, minute, second;

    // Health, Food, WC, Play, Sleep, Lovis, Whatter
    public List<DepositController> deposits;
    public void Awake()
    {
        Debug.Log("I'm Awake");
        UpdateDeposits();
    }
    public void OnApplicationPause(bool pause)
    {
        Debug.Log("I'm OnApplicationPause");
        SaveToFile();
    }
    private void OnApplicationQuit()
    {
        Debug.Log("I'm OnApplicationQuit");
        SaveToFile();
    }
    void Update()
    {
        //Debug.Log("Date: " + System.DateTime.Now.Day + ":" + System.DateTime.Now.Month + ":" + System.DateTime.Now.Year + " Hora: " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + ":" + System.DateTime.Now.Millisecond);

    }
    public void SaveToFile()
    {

        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;
        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        second = System.DateTime.Now.Second;

        DataDeposits data = new DataDeposits(day, month, year, hour, minute, second, 
            deposits[0].percentage, deposits[1].percentage, deposits[2].percentage, 
            deposits[3].percentage, deposits[4].percentage, deposits[5].percentage, deposits[6].percentage,
            deposits[0].substractionPerSeconds, deposits[1].substractionPerSeconds, deposits[2].substractionPerSeconds,
            deposits[3].substractionPerSeconds, deposits[4].substractionPerSeconds, deposits[5].substractionPerSeconds, deposits[6].substractionPerSeconds);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.gd");
        bf.Serialize(file, data);
        file.Close();

    }

    public void UpdateDeposits()
    {

        //Debug.Log("In UpdateDeposits");
        if (File.Exists(Application.persistentDataPath + "/savedGame.gd"))
        {
            //Debug.Log("In FileExist");

            DataDeposits data;
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
            data = (DataDeposits)bf.Deserialize(file);

            file.Close();

            deposits[0].UpdateTime(data.depHealth, data.SPSHealth, data.day, data.month, data.year, data.hour, data.minute, data.second);
            deposits[1].UpdateTime(data.depFood, data.SPSFood, data.day, data.month, data.year, data.hour, data.minute, data.second);
            deposits[2].UpdateTime(data.depWC, data.SPSWC, data.day, data.month, data.year, data.hour, data.minute, data.second);
            deposits[3].UpdateTime(data.depPlay, data.SPSPlay, data.day, data.month, data.year, data.hour, data.minute, data.second);
            deposits[4].UpdateTime(data.depSleep, data.SPSSleep, data.day, data.month, data.year, data.hour, data.minute, data.second);
            deposits[5].UpdateTime(data.depLovis, data.SPSLovis, data.day, data.month, data.year, data.hour, data.minute, data.second);
            deposits[6].UpdateTime(data.depWater, data.SPSWater, data.day, data.month, data.year, data.hour, data.minute, data.second);
        }

    }
}
