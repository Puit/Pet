using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{

    public Button left, right;
    public GameObject myObject;
    public CanvasController canvas;
    public Vector3 startPosition;
    //public List<>

    void Start()
    {
        startPosition = myObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (canvas.objectTouched)
        //{
        //    myObject.transform.position = canvas.fingerPosition;
        //}
        //else
        //{
        //    myObject.transform.position = Vector3.Lerp(myObject.transform.position, startPosition, 5f * Time.deltaTime);
        //}
    }
}
