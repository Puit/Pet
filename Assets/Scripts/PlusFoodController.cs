
using UnityEngine;


public class PlusFoodController : MonoBehaviour
{
    SceneController scene;
    private void Start()
    {

        scene = FindObjectOfType<SceneController>();
    }
    public void Clicked()
    {
        scene.ShowFoodPanel();
    }

}
