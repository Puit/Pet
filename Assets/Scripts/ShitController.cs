using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitController : MonoBehaviour
{
    public DepositController WCDeposit;
    public List<GameObject> shits;
    public GameObject point1, point2;
    public CanvasController canvas;

    private GameObject shitInScene; //To instantiate an object it is need to related with something

    private void Start()
    {
        canvas = FindObjectOfType<CanvasController>();
    }
    public void Update()
    {
        //We place a random shit in a random place in the area between point1 and point2
        if (WCDeposit.percentage == 0)
        {
            WCDeposit.percentage = 50f;
            Vector3 p1, p2;
            p1 = point1.transform.position;
            p2 = point2.transform.position;
            Vector3 position = new Vector3(Random.Range(p1.x, p2.x), Random.Range(p1.y, p2.y), Random.Range(p1.z, p2.z));
            shitInScene = GameObject.Instantiate(shits[Random.Range(0, shits.Count)], position, Quaternion.identity) as GameObject;
            
        }
        if (canvas.fingerDown)
        {
            ShitsDestroyer();
        }
    }
    public void ShitsDestroyer()
    {
        //Debug.Log(canvas.GetTouchedTag());
        if (canvas.GetTouchedTag().Equals("Shit"))
        {

            canvas.DestroyObject();
        }
    }
}
