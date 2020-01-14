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

    //Index respecte el FoodObject (el d'exemple) y  el FoodObjectBig
    [SerializeField]
    public List<int> FoodObjectsList;
    public List<int> HealthObjectsList, PlayObjectsList, SleepObjectsList;

    //This is the example of all
    public List<GameObject> FoodObjects, HealthObjects, PlayObjects, SleepObjects;
    public List<GameObject> FoodObjectsBig, HealthObjectsBig, PlayObjectsBig, SleepObjectsBig;
    public List<GameObject> FoodObjectsSimple, HealthObjectsSimple, PlayObjectsSimple, SleepObjectsSimple;

    public DataType myDataType;

    public GameObject actualObject;

    public int size, actualIndex = 0;

    public bool dragging = false;

    public void OnStart()
    {

        //FoodObjectsBig = FoodObjects;
        //HealthObjectsBig = HealthObjects;
        //PlayObjectsBig = PlayObjects;
        //SleepObjectsBig = SleepObjects;

        IntListToBigList(FoodObjectsList, FoodObjects, FoodObjectsBig);
        IntListToBigList(HealthObjectsList, HealthObjects, HealthObjectsBig);
        IntListToBigList(PlayObjectsList, PlayObjects, PlayObjectsBig);
        IntListToBigList(SleepObjectsList, SleepObjects, SleepObjectsBig);

        startPosition = myObject.transform.position;
        //InstantiateObject(0, FoodObjects);
        SimplifyList(FoodObjectsBig, FoodObjectsSimple);
        SimplifyList(HealthObjectsBig, HealthObjectsSimple);
        SimplifyList(PlayObjectsBig, PlayObjectsSimple);
        SimplifyList(SleepObjectsBig, SleepObjectsSimple);

        ShowFoodObjects();

        //Easy way to show the number of objects
        //GoLeftButton();
        GoRightButton();
    }
    public void IntListToBigList(List<int> intList, List<GameObject> objectList, List<GameObject> bigList)
    {
        if (intList.Count > 1) 
        {
            foreach (int i in intList)
            {
                bigList.Add(objectList[i]);
            }
        }
        else
        {
            bigList.Add(objectList[0]);
            intList.Add(0);
        }

    }

    public void InstantiateObject(int index, List<GameObject> listOfObjects)
    {
        actualObject = Instantiate(listOfObjects[index], myObject.transform.position, myObject.transform.rotation, transform);
        actualObject.transform.SetAsFirstSibling(); //Sets it at the first position so we can see the number of objects
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
                ShowQuantity(FoodObjectsSimple[actualIndex], FoodObjectsSimple);
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
                ShowQuantity(FoodObjectsSimple[actualIndex], FoodObjectsSimple);
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
            //size = listOfObjects.Count;
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
            //size = listOfObjects.Count;
            
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

        foreach (GameObject b in bigList)
        {
            if (!simpleList.Contains(b))
                simpleList.Add(b);
        }
        foreach(GameObject s in simpleList)
        {
            if (!bigList.Contains(s))
                simpleList.Remove(s);
        }
        //Debug.Log("POSTCOUNT: " + simpleList.Count);
        //Prevent that it doesn't instantiate again the object that is not in list anymore
        if (pre > simpleList.Count)
            GoLeftButton();

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
            foreach(GameObject o in FoodObjectsBig)
            {
                if (g.name.Contains(o.name))
                {
                    g = o;
                }
            }
            int index = FoodObjectsBig.IndexOf(g);
            FoodObjectsList.Remove(FoodObjectsList[index]);
            FoodObjectsBig.Remove(g);
            SimplifyList(FoodObjectsBig, FoodObjectsSimple);
            //Change Number
            ShowQuantity(g, FoodObjectsBig);
        }


        if (g.GetComponent<HealthController>())
        {

            HealthObjectsBig.Remove(g);
            SimplifyList(HealthObjectsBig, HealthObjectsSimple);
            //Change Number
            ShowQuantity(g, HealthObjectsBig);
        }
    }
    public void AddFoodObject(GameObject o)
    {
        FoodObjectsBig.Add(o);
        FoodObjectsList.Add(FoodObjects.IndexOf(o));
    }
    public void AddHealthObject(GameObject o)
    {
        HealthObjectsBig.Add(o);
        HealthObjectsList.Add(HealthObjects.IndexOf(o));
    }
}
