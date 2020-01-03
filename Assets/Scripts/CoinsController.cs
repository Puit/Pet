using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    Text text;
    public int quantity = 0;
    public List<GameObject> coinsList;
    public CanvasController canvas;
    public float speed = 10f;

    void Start()
    {
        text = GetComponentInChildren<Text>();
        canvas = FindObjectOfType<CanvasController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (quantity > 9)
            text.text = quantity.ToString();
        else
            text.text ="0" + quantity.ToString();
    }

    public void InstantiateCoin()
    {
        Debug.Log("Hello it's me");
        GameObject coin = Instantiate(coinsList[Random.Range(0, coinsList.Count)], canvas.GetTouchedPosition(), Quaternion.identity) as GameObject;
        coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1f) * speed, ForceMode2D.Impulse);
    }
}
