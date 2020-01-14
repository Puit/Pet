using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionButtonController : MonoBehaviour
{
    public GameObject pressedImage;
    private void Start()
    {
        pressedImage.gameObject.SetActive(false);
    }
    public void Presed()
    {
        PacmanController pacman = FindObjectOfType<PacmanController>();
        pressedImage.gameObject.SetActive(true);

        if (gameObject.name.Equals("Right")) pacman._nextDir = Vector2.right;
        if (gameObject.name.Equals("Left")) pacman._nextDir = -Vector2.right;
        if (gameObject.name.Equals("Up")) pacman._nextDir = Vector2.up;
        if (gameObject.name.Equals("Down")) pacman._nextDir = -Vector2.up;
    }
    public void Unpresed()
    {
        pressedImage.gameObject.SetActive(false);
    }
}
