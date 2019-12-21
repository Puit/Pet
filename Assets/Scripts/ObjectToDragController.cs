using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectToDragController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private CanvasController canvas;
    private void Start()
    {
        startPosition = transform.position;
        canvas = FindObjectOfType<CanvasController>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
        if (Input.GetMouseButtonDown(0)) //NO VA PERQUE BUSQUEM EL INPUT MOUSE POSITION I NO HI HA MOUSE JA QUE S'HA AIXECAT EL DIT
        {
            string tag;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {

                tag =  hit.collider.tag;

            }
            Debug.Log("TAG: " + hit.collider.tag);
        }
        
    }
}

//transform.position = startPosition;
//        if (Input.GetMouseButtonDown(0))
//        {
//            string tag;
//Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
////RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
//RaycastHit2D[] hit = Physics2D.RaycastAll(pos, Vector2.zero);
//Debug.Log("IN: ");
//            foreach (RaycastHit2D h in hit)
//            {
//                Debug.Log("IN  ");
//                if (h.collider != null)
//                {
//                    tag = h.collider.tag;
//                    Debug.Log("TAG: " + tag);
//                }
//            }
//            //if (hit.collider != null)
//            //{

//            //    tag =  hit.collider.tag;

//            //}
//        }
//        //Debug.Log("TAG: "+ tag);