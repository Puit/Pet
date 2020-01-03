using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{

    //public Button left, right;
    public GameObject myObject;
    public Image quantityImage;
    public TextMeshProUGUI quantityText;

    public CanvasController canvas;
    public Vector3 startPosition;

    public List<GameObject> FoodObjects, HealthObjects, PlayObjects, SleepObjects;
    public List<GameObject> FoodObjectsSimple, HealthObjectsSimple, PlayObjectsSimple, SleepObjectsSimple;

    public DataType myDataType;

    public GameObject actualObject;

    private int size, actualIndex = 0;

    public bool dragging = false;

    void Start()
    {
        startPosition = myObject.transform.position;
        //InstantiateObject(0, FoodObjects);
        SimplifyList(FoodObjects, FoodObjectsSimple);
        SimplifyList(HealthObjects, HealthObjectsSimple);
        SimplifyList(PlayObjects, PlayObjectsSimple);
        SimplifyList(SleepObjects, SleepObjectsSimple);

        ShowFoodObjects();

    }

    public void InstantiateObject(int index, List<GameObject> listOfObjects)
    {
        actualObject = Instantiate(listOfObjects[index], myObject.transform.position, myObject.transform.rotation, transform);
        
    }
    public void RemoveActualObject()
    {
        Destroy(actualObject);
    }

    public int GetIndexActualObject(List<GameObject> listOfObjects)
    {
        int i = 0;
        int index = -5;
        foreach(GameObject g in listOfObjects)
        {
            if (actualObject.name.Equals(g.name + "(Clone)"))
                index = i;
            i++;
        }
        return index;
    }

    public void GoLeftButton()
    {
        switch (myDataType)
        {
            case DataType.Food:
                GoLeft(FoodObjectsSimple);
                break;
            case DataType.Health:
                GoLeft(HealthObjectsSimple);
                break;
            case DataType.Lovis:

                break;
            case DataType.Play:
                GoLeft(PlayObjectsSimple);
                break;
            case DataType.Sleep:
                GoLeft(SleepObjectsSimple);
                break;
            case DataType.Water:

                break;
            case DataType.WC:

                break;
            default:

                break;
        }
    }
    public void GoRightButton()
    {
        switch (myDataType)
        {
            case DataType.Food:
                GoRight(FoodObjectsSimple);
                break;
            case DataType.Health:
                GoRight(HealthObjectsSimple);
                break;
            case DataType.Lovis:

                break;
            case DataType.Play:
                GoRight(PlayObjectsSimple);
                break;
            case DataType.Sleep:
                GoRight(SleepObjectsSimple);
                break;
            case DataType.Water:

                break;
            case DataType.WC:

                break;
            default:

                break;
        }
    }
    private void GoRight(List<GameObject> listOfObjects)
    {
        size = listOfObjects.Count;
        //actualIndex = GetIndexActualObject(listOfObjects);

        if (actualIndex >= 0)
        {
            RemoveActualObject();
            if ((actualIndex + 1) == size)
            {
                InstantiateObject(0, listOfObjects);
                actualIndex = 0;
            }
            else
            {
                InstantiateObject(actualIndex + 1, listOfObjects);
                actualIndex++;
            }
        }
    }
    private void GoLeft(List<GameObject> listOfObjects)
    {
        size = listOfObjects.Count;
        //actualIndex = GetIndexActualObject(listOfObjects);

        if (actualIndex >= 0)
        {
            RemoveActualObject();
            if ((actualIndex) == 0)
            {
                InstantiateObject(size - 1, listOfObjects);
                actualIndex = size - 1;
            }
            else
            {
                InstantiateObject(actualIndex - 1, listOfObjects);
                actualIndex--;
            }
                
        }
    }
    public void ShowFoodObjects()
    {
        RemoveActualObject();
        InstantiateObject(0, FoodObjectsSimple);
        myDataType = DataType.Food;
    }
    public void ShowHealthObjects()
    {
        RemoveActualObject();
        InstantiateObject(0, HealthObjectsSimple);
        myDataType = DataType.Health;
    }
    public void ShowSleepObjects()
    {
        RemoveActualObject();
        InstantiateObject(0, SleepObjectsSimple);
        myDataType = DataType.Sleep;
    }
    public void ShowPlayObjects()
    {
        RemoveActualObject();
        InstantiateObject(0, PlayObjectsSimple);
        myDataType = DataType.Play;
    }

    public void SimplifyList(List<GameObject> bigList, List<GameObject> simpleList)
    {
        int pre = simpleList.Count;
        simpleList.Clear();
        
        foreach(GameObject b in bigList)
        {
            if (!simpleList.Contains(b))
                simpleList.Add(b);
        }
        //Prevent that it doesn't instantiate again the object that is not in list anymore
        if (pre > simpleList.Count)
            GoRightButton();

    }
    public void ShowQuantity(GameObject g, List<GameObject> l)
    {
        int quantity = 0;
        foreach(GameObject x in l)
        {
            if (x == g)
                quantity++;
        }
        if (quantity > 0)
        {
            quantityImage.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else
        {
            quantityImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }
    public void RemoveObjectFromList(GameObject g)
    {
        Debug.Log("IN");
        if (g.GetComponent<FoodController>() || g.GetComponent<WaterController>())
        {
            foreach(GameObject o in FoodObjects)
            {
                if (g.name.Contains(o.name))
                {
                    g = o;
                }
            }
            FoodObjects.Remove(g);
            SimplifyList(FoodObjects, FoodObjectsSimple);
            //Change Number
            ShowQuantity(g, FoodObjects);
        }
        if (g.GetComponent<HealthController>())
        {
            
            HealthObjects.Remove(g);
            SimplifyList(HealthObjects, HealthObjectsSimple);
            //Change Number
            ShowQuantity(g, HealthObjects);
        }
    }
}
