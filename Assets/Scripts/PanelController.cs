using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public ObjectsController objects;
    public void ChangeToFood()
    {
        objects.ShowFoodObjects();
    }
    public void ChangeToHealth()
    {
        objects.ShowHealthObjects();
    }
    public void ChangeToPlay()
    {
        objects.ShowPlayObjects();
    }
    public void ChangeToSleep()
    {
        objects.ShowSleepObjects();
    }
}
