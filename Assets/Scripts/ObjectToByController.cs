using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectToByController : MonoBehaviour
{
    CoinsController coins;
    public int price;
    public Image icon;
    public Image coinIcon;
    public TextMeshProUGUI priceText;
    public GameObject objectToBuy;

    public ObjectsController objectsController;

    void Start()
    {
        coins = FindObjectOfType<CoinsController>();
        objectsController = FindObjectOfType<ObjectsController>();
        if (price == 0)
        {
            coinIcon.color = new Color(255f,255f,255f,0f); //Invisible Color
            priceText.text = "";
        }
        else
        {
            coinIcon.color = new Color(255f, 255f, 255f, 255f); //Invisible Color
            priceText.text = price.ToString();
            //Debug.Log(objectToBuy.GetComponent<Image>());
            icon.sprite = objectToBuy.GetComponent<Image>().sprite;
        }
    }

    public void ButtonCliked()
    {
        if(coins.quantity - price >= 0)
        {
            coins.quantity -= price;
            if (objectToBuy.GetComponent<FoodController>() || objectToBuy.GetComponent<WaterController>())
            {
                objectsController.AddFoodObject(objectToBuy);
                objectsController.SimplifyList(objectsController.FoodObjectsBig, objectsController.FoodObjectsSimple);
            }
                
            if (objectToBuy.GetComponent<HealthController>())
            {
                objectsController.AddHealthObject(objectToBuy);
                objectsController.SimplifyList(objectsController.HealthObjectsBig, objectsController.HealthObjectsSimple);
            }
        }
    }
}
