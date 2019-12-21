using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject irisR;
    public GameObject irisL;
    private Vector3 startPositionR;
    private Vector3 startPositionL;
    private float elapse = 0;
    void Start()
    {
        startPositionR = irisR.transform.position;
        startPositionL = irisL.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUp()
    {
        irisR.transform.position = Vector3.Lerp(transform.position, startPositionR, elapse);
        irisL.transform.position = Vector3.Lerp(transform.position, startPositionL, elapse);
    }
    private void OnMouseDrag()
    {
        irisR.transform.position = Vector3.Lerp(transform.position, startPositionR, elapse);
        irisL.transform.position = Vector3.Lerp(transform.position, startPositionL, elapse);
    }
}
