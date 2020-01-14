using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public int day, month, year, hour, minute, second;
    public CoinsController coins;
    public Transform foodPanel;
    public ObjectsController objectsController;

    // Health, Food, WC, Play, Sleep, Lovis, Whatter
    public List<DepositController> deposits;
    public void Awake()
    {
        Debug.Log("I'm Awake");
        //Debug.Log(Application.persistentDataPath + "/coins.gd");
        UpdateDeposits();
        UpdateCoins();

        //Deploys how many objects do I have
        UpdateObjects();
        objectsController.OnStart();
    }
    public void OnApplicationPause(bool pause)
    {
        Debug.Log("I'm OnApplicationPause");
        SaveDeposits();
        SaveCoins();
        //Detect if sleeping and save it
        //Detect how many poops need to place

        //Save how many objects do I have
        SaveObjects();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("I'm OnApplicationQuit");
        SaveDeposits();
        SaveCoins();

        //Save how many objects do I have
        SaveObjects();
    }
    void calcularpercentatge(float ingresoEntrada, float porcentatge, float anys)
    {
        float suma = ingresoEntrada;
       
        for(int i = 0; i <= anys; i++)
        {
            suma += porcentatge * ingresoEntrada;
            i++;
            Debug.Log("LA i " + i);
        }
        Debug.Log("Resultado: " + suma);
    }
    private void Start()
    {
        calcularpercentatge(9300f, 4f, 20f);
    }
    void Update()
    {
        //Debug.Log("Date: " + System.DateTime.Now.Day + ":" + System.DateTime.Now.Month + ":" + System.DateTime.Now.Year + " Hora: " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + ":" + System.DateTime.Now.Millisecond);

    }
    public void SaveDeposits()
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
        //FileStream file = File.Create(Application.persistentDataPath + pathAndFileName);
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
    public void SaveObjects()
    {

        //string data = objectsController.FoodObjects;
        Debug.Log("In FileSave");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/foodObjects.gd");

        bf.Serialize(file, objectsController.FoodObjectsList);
        file.Close();
        foreach (int i in objectsController.FoodObjectsList)
        {
            Debug.Log(i);
        }

    }
    public void UpdateObjects()
    {
        //Debug.Log("In UpdateDeposits");
        if (File.Exists(Application.persistentDataPath + "/foodObjects.gd"))
        {
            Debug.Log("In FileExist");
            
            List<int> data;
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/foodObjects.gd", FileMode.Open);
            data = (List<int>)bf.Deserialize(file);

            file.Close();

            foreach(int i in data)
            {
                Debug.Log(i);
            }
            objectsController.FoodObjectsList = data;
        }
    }
    public void SaveCoins()
    {

        int data = coins.quantity;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/coins.gd");

        bf.Serialize(file, data);
        file.Close();

    }

    public void UpdateCoins()
    {
        if (File.Exists(Application.persistentDataPath + "/coins.gd"))
        {
            int data;
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/coins.gd", FileMode.Open);
            data = (int)bf.Deserialize(file);

            file.Close();

            coins.quantity = data;
        }
    }
    public void ShowFoodPanel()
    {
        //foodPanel.enabled = true;
        foodPanel.gameObject.SetActive(true);
    }
    public void HideFoodPanel()
    {
        //foodPanel.enabled = false;
        foodPanel.gameObject.SetActive(false);
    }
}
