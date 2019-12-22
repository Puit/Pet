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

    private void Start()
    {
        canvas = FindObjectOfType<CanvasController>();
    }
    
    void Update()
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
            deposits[5].percentage += 5f *Time.deltaTime;
            animator.SetBool("Touched", true);
        }
        else
        {
            animator.SetBool("Touched", false);
        }


        if(lovis < 20f && !canvas.playerTouched && !sleeping) 
        {
            animator.SetBool("NeedLovis", true);
        }
        else
        {
            animator.SetBool("NeedLovis", false);
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
        sleeping = true;
        animator.SetBool("Sleeping", true);
    }
    public void SleepingOff()
    {
        sleeping = false;
        animator.SetBool("Sleeping", false);
    }
}
