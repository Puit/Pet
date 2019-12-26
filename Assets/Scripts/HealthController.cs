using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealthController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private CanvasController canvas;
    public float incrementation = 5f;

    private Vector3 acceleration;
    public DepositController health;

    private ObjectsController objects;
    //private SpriteRenderer mouth;
    private void Start()
    {
        DepositController[] deposits = FindObjectsOfType<DepositController>();
        objects = FindObjectOfType<ObjectsController>();

        foreach (DepositController dep in deposits)
        {
            //Debug.Log("IN FOREACH");
            if (dep.name.Equals("Health"))
            {
                //Debug.Log("IN IF");
                health = dep.GetComponent<DepositController>();
            }
        }

        startPosition = transform.position;
        canvas = FindObjectOfType<CanvasController>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        acceleration = Input.acceleration;
        objects.dragging = true;

        Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        //    if (hit.collider != null)
        //    {
        //        if (hit.collider.name.Equals("Head"))
        //        {

        //            Debug.Log("Change to open"); //NO CAMBIA PORQUE EL ANIMATION FUERZA A QUE SE MANTENGA OTRA VOCA
        //        }

        //    }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        string tag = "";
        Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        if (hit.collider != null)
        {
            tag = hit.collider.tag;
        }
        if (tag.Equals("Player"))
        {
            CobiController cobi = hit.collider.GetComponent<CobiController>();

            health.percentage += incrementation;
        }

        transform.position = startPosition;
        objects.dragging = false;
    }
}
