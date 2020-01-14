using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
public void GoTo(string scene)
    {
        Scene s = FindObjectOfType<Scene>();
        EditorSceneManager.CloseScene(s, true); 
        SceneManager.LoadScene(scene);
    }
}
