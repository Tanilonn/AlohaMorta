using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    public string Scene;
    public bool Locked;

    private void OnMouseDown()
    {
        //change scene
        if (!Locked)
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
