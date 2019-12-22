using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectToDragController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private CanvasController canvas;

    private Vector3 acceleration;
    private void Start()
    {
        startPosition = transform.position;
        canvas = FindObjectOfType<CanvasController>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        acceleration = Input.acceleration;

        Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        string tag = "";
        Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        if (hit.collider != null)
        {
            tag =  hit.collider.tag;
        }
        if (tag.Equals("Player"))
        {
            CobiController cobi = hit.collider.GetComponent<CobiController>();
            
        }

        transform.position = startPosition;
    }
}