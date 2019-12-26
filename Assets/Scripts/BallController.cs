using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BallController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    //private CanvasController canvas;
    public float incrementation = 5f;

    //private Vector3 acceleration;
    public DepositController play;

    private ObjectsController objects;

    private Rigidbody2D myRigidbody;
    private float lastMouseX, lastMouseY;

    private float time = 0f, lastTime = 0f;
    public float multiplier = 3.5e+07f;
    //private SpriteRenderer mouth;

    //public Sprite mouthOpen, previouseMouth;
    private void Start()
    {
        DepositController[] deposits = FindObjectsOfType<DepositController>();
        objects = FindObjectOfType<ObjectsController>();
        
        myRigidbody = GetComponentInParent<Rigidbody2D>();
        foreach (DepositController dep in deposits)
        {
            if (dep.name.Equals("Play"))
            {
                
                play = dep.GetComponent<DepositController>();
            }
        }

        startPosition = transform.position;
        //canvas = FindObjectOfType<CanvasController>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        //acceleration = Input.acceleration;
        objects.dragging = true;
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.gravityScale = 0f;

        time += Time.deltaTime;
        if(time >= lastTime + 0.3)
        {
            lastMouseX = Camera.main.ScreenToWorldPoint(transform.position).x;
            lastMouseY = Camera.main.ScreenToWorldPoint(transform.position).y;
            lastTime = time;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        time = 0f;
        lastTime = 0f;
        Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        float differenceY = (pos.y - lastMouseY) / Screen.height * 100;
        float speed = 35f * differenceY;

        float x = (pos.x / Screen.width) - (lastMouseX / Screen.width);
        float y = (pos.y / Screen.height) - (lastMouseY / Screen.height);
        //x = Mathf.Abs(Input.GetTouch(0).position.x - lastMouseX) / Screen.width * 100 * x;
        
        x = Mathf.Abs(Camera.main.ScreenToWorldPoint(transform.position).x - lastMouseX) / Screen.width * 100 * x;
        y = Mathf.Abs(Camera.main.ScreenToWorldPoint(transform.position).y - lastMouseY) / Screen.width * 100 * y;


        Vector3 direction = new Vector3(x * multiplier, y * multiplier, 1f);
        direction = Camera.main.transform.TransformDirection(direction);
        myRigidbody.AddForce((direction * speed / 2f) + (Vector3.up * speed));
        myRigidbody.gravityScale = 5f;
        objects.dragging = false;
    }
    private void Update()
    {
        //Debug.Log(myRigidbody.velocity);
        if(myRigidbody.velocity.x != 0f || myRigidbody.velocity.y != 0f)
            play.percentage += 5f * Time.deltaTime;

        //Debug.Log("x " + myRigidbody.velocity.x + " y " + myRigidbody.velocity.y);
        if ((Mathf.Abs(myRigidbody.velocity.x) <= 4f || Mathf.Abs(myRigidbody.velocity.y) <= 4f) && !objects.dragging)
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, 3f * Time.deltaTime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.gravityScale = 0f;
        }   
    }
}
