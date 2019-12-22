using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{

    //public Button left, right;
    public GameObject myObject;
    public CanvasController canvas;
    public Vector3 startPosition;

    public List<GameObject> FoodObjects, HealthObjects, PlayObjects, SleepObjects;
    public DataType myDataType;

    public GameObject actualObject;

    private int size, actualIndex;

    public bool dragging = false;

    void Start()
    {
        startPosition = myObject.transform.position;
        //InstantiateObject(0, FoodObjects);
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
                GoLeft(FoodObjects);
                break;
            case DataType.Health:
                GoLeft(HealthObjects);
                break;
            case DataType.Lovis:

                break;
            case DataType.Play:
                GoLeft(PlayObjects);
                break;
            case DataType.Sleep:
                GoLeft(SleepObjects);
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
                GoRight(FoodObjects);
                break;
            case DataType.Health:
                GoRight(HealthObjects);
                break;
            case DataType.Lovis:

                break;
            case DataType.Play:
                GoRight(PlayObjects);
                break;
            case DataType.Sleep:
                GoRight(SleepObjects);
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
        actualIndex = GetIndexActualObject(listOfObjects);

        if (actualIndex >= 0)
        {
            RemoveActualObject();
            if ((actualIndex + 1) == size)
            {
                InstantiateObject(0, listOfObjects);
            }
            else
            {
                InstantiateObject(actualIndex + 1, listOfObjects);
            }
        }
    }
    private void GoLeft(List<GameObject> listOfObjects)
    {
        size = listOfObjects.Count;
        actualIndex = GetIndexActualObject(listOfObjects);

        if (actualIndex >= 0)
        {
            RemoveActualObject();
            if ((actualIndex) == 0)
                InstantiateObject(size - 1, listOfObjects);
            else
                InstantiateObject(actualIndex - 1, listOfObjects);
        }
    }
    public void ShowFoodObjects()
    {
        RemoveActualObject();
        InstantiateObject(0, FoodObjects);
        myDataType = DataType.Food;
    }
    public void ShowHealthObjects()
    {
        RemoveActualObject();
        InstantiateObject(0, HealthObjects);
        myDataType = DataType.Health;
    }
    public void ShowSleepObjects()
    {
        RemoveActualObject();
        InstantiateObject(0, SleepObjects);
        myDataType = DataType.Sleep;
    }
    public void ShowPlayObjects()
    {
        RemoveActualObject();
        InstantiateObject(0, PlayObjects);
        myDataType = DataType.Play;
    }

}
