using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public enum PetColor {Blue, Green, Yellow, Red, White};
    public PetColor nextStateColor = PetColor.Blue;
    public List<GameObject> prefabList;
    public bool evolve = false;
    public Animator animator;
    private bool touched = false;

    public CanvasController canvas;

    private void Start()
    {
        canvas = FindObjectOfType<CanvasController>();
    }
    public void Evolve()
    {
        GameObject myPrefab = prefabList[0];
        foreach (GameObject prefab in prefabList)
        {
            if(prefab.name.Equals("Baby"+ nextStateColor.ToString())){
                myPrefab = prefab;
            }
        }
        if (myPrefab != null) 
            Instantiate(myPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (evolve)
            Evolve();
        if (canvas.fingerDown)
        {
            FingerDrag();
        }
        else
        {
            if(transform.rotation != Quaternion.identity)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 5f * Time.deltaTime);
        }
    }
    private void OnMouseDown()
    {
 
        animator.SetTrigger("Jump");
        //Debug.Log("ONMOUSEDOWN");
        touched = true;
      
    }
    private void FingerDrag()
    {
        if(canvas.fingerDown)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, canvas.fingerPosition - transform.position);
            if (rotation.z < 0.2 && rotation.z > -0.2)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5f * Time.deltaTime);
            }
        }


    }

    private void OnMouseUp()
    {
        touched = false; 
        transform.rotation = Quaternion.identity;
    }

}
