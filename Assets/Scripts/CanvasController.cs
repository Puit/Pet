using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public bool fingerDown = false;
    public bool playerTouched = false;
    public bool objectTouched = false;
    public Vector3 fingerPosition;

    private void Update()
    {
        //If mouse is down
        if (Input.GetMouseButtonDown(0))
        {
            fingerPosition = new Vector3(Input.mousePosition.x - (Screen.width/2), Input.mousePosition.y - (Screen.height / 2), Input.mousePosition.z);
            fingerDown = true;

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit != null && hit.collider != null)
            {
                //Debug.Log("I'm hitting " + hit.collider.name);
                if (hit.collider.tag == "Player")
                    playerTouched = true;
                else
                    playerTouched = false;
                if (hit.collider.tag == "Object")
                    objectTouched = true;
                else
                    objectTouched = false;
                Debug.Log("Object Touchet: " + objectTouched);
            }
        }

        //If mouse is up
        if (Input.GetMouseButtonUp(0))
        {   
            fingerDown = false;
            playerTouched = false;
            //Debug.Log("Mouse UP");
        }
        //If finger still down
        if (fingerDown)
        {
            fingerPosition = new Vector3(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2), Input.mousePosition.z);
        }
    }
    public string GetTouchedTag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fingerPosition = new Vector3(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2), Input.mousePosition.z);
            fingerDown = true;

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit != null && hit.collider != null)
            {

                return hit.collider.tag;
                
            }
        }
        return "";
    }
}
