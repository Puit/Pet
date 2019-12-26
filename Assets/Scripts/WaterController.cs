using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WaterController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private CanvasController canvas;
    public float incrementation = 5f;

    private Vector3 acceleration;
    public DepositController food;

    private ObjectsController objects;
    private SpriteRenderer mouth;

    public Sprite mouthOpen, previouseMouth;
    private void Start()
    {
        DepositController[] deposits = FindObjectsOfType<DepositController>();
        objects = FindObjectOfType<ObjectsController>();
        SpriteRenderer[] sprites = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer s in sprites)
        {
            if (s.name.Equals("Mouth"))
                mouth = s;
        }

        foreach (DepositController dep in deposits)
        {
            //Debug.Log("IN FOREACH");
            if (dep.name.Equals("Water"))
            {
                //Debug.Log("IN IF");
                food = dep.GetComponent<DepositController>();
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
        if (previouseMouth != mouthOpen)
        {
            previouseMouth = mouth.sprite;
            Debug.Log("Previouse mouth");
        }

        if (hit.collider != null)
        {
            if (hit.collider.name.Equals("Head"))
            {
                mouth.sprite = mouthOpen;
                Debug.Log("Change to open"); //NO CAMBIA PORQUE EL ANIMATION FUERZA A QUE SE MANTENGA OTRA VOCA
            }

            else
            {
                mouth.sprite = previouseMouth;
                Debug.Log("Change to previouse");
            }

        }
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

            food.percentage += incrementation;
        }

        transform.position = startPosition;
        objects.dragging = false;
    }
}
