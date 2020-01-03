using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobiController : MonoBehaviour
{
    //public List<GameObject> prefabList;
    //public bool evolve = false;
    public Animator animator;
    //private bool touched = false;
    public GameObject head;
    // Health, Food, WC, Play, Sleep, Lovis, Whatter
    public List<DepositController> deposits;
    public float health, food, WC, play, sleep, lovis, whatter;

    public CanvasController canvas;
    public ObjectsController objects;
    private bool sleeping = false;

    public GameObject eyeBacks, cheeks, mouth;
    public Sprite mouthHappy, mouthSad;

    public float coinTime = 5f;
    private float coinTimer = 0f;
    CoinsController coinsController;

    private void Start()
    {
        canvas = FindObjectOfType<CanvasController>();
        coinsController = FindObjectOfType<CoinsController>();
    }
    
    void Update()
    {
        //When Sleeping, the gameObjects is set inactive and everything is fucked up :) so I solved in a simple Try Catch
        try
        {
            health = deposits[0].percentage;
            food = deposits[1].percentage;
            WC = deposits[2].percentage;
            play = deposits[3].percentage;
            sleep = deposits[4].percentage;
            lovis = deposits[5].percentage;
            whatter = deposits[6].percentage;

            if (canvas.fingerDown)
            {
                FingerDrag();
            }
            else
            {
                if (transform.rotation != Quaternion.identity)
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 5f * Time.deltaTime);
            }
            if (canvas.playerTouched && !objects.dragging && !sleeping)
            {
                deposits[5].percentage += 5f * Time.deltaTime;
                animator.SetBool("Touched", true);

                if (coinTimer <= 0)
                {
                    coinTimer = coinTime;
                    coinsController.InstantiateCoin();
                }
            }
            else
            {
                animator.SetBool("Touched", false);
            }


            if (lovis < 20f && !canvas.playerTouched && !sleeping)
            {
                animator.SetBool("NeedLovis", true);

            }
            else
            {
                animator.SetBool("NeedLovis", false);
            }

            if (sleeping)
            {
                Debug.Log("IN SLEEPING");
                deposits[4].percentage += 2f * Time.deltaTime;
            }

            if (sleep < 20f)
            {
                eyeBacks.SetActive(true);
                //mouth.GetComponent<SpriteRenderer>().sprite = mouthSad;
            }
            else
                eyeBacks.SetActive(false);
            //mouth.GetComponent<SpriteRenderer>().sprite = mouthHappy;

            if (health < 20f)
            {
                cheeks.SetActive(true);
                //mouth.GetComponent<SpriteRenderer>().sprite = mouthSad;
            }
            else
            {
                cheeks.SetActive(false);
                //mouth.GetComponent<SpriteRenderer>().sprite = mouthHappy;
            }
            if (sleep < 20f || health < 20f)
                mouth.GetComponent<SpriteRenderer>().sprite = mouthSad;
            else
                mouth.GetComponent<SpriteRenderer>().sprite = mouthHappy;

            if (coinTimer > 0)
                coinTimer -= Time.deltaTime;
        }
        catch (Exception e)
        {

        }
        
    }
    private void FingerDrag()
    {
        if (canvas.fingerDown)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, canvas.fingerPosition - transform.position);
            if (rotation.z < 0.9 && rotation.z > -0.9)
            {
                head.transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 3f * Time.deltaTime);
            }
        }
    }
    public void SleepingOn()
    {
        Debug.Log("SleepingOn");
        sleeping = true;
        Debug.Log("SleepingOn");
        //animator.SetBool("Sleeping", true);
    }
    public void SleepingOff()
    {
        Debug.Log("SleepingOFF");
        sleeping = false;
        Debug.Log("SleepingOFF");
        //animator.SetBool("Sleeping", false);
    }
}
