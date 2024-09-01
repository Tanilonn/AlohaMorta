using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenRecording : MonoBehaviour
{
    public string Scene;
    public Texture2D cursor;

    private void OnMouseDown()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene(Scene);
    }

    void OnMouseEnter()
    {        
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);        
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }


}
