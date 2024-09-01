using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    public string Scene;
    public bool Locked;
    public int UnlockObjective;
    public Sprite unlocked;
    public SpriteRenderer door;
    private GameManager manager;
    public Texture2D cursor;
    public bool flip;



    private void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (UnlockObjective != 0 && manager.Objectives[UnlockObjective].Completed)
        {
            Unlock();
        }
    }

    private void Unlock()
    {
        Locked = false;        
        door.sprite = unlocked;
        if (flip)
        {
            door.flipX = true;

        }

    }

    private void OnMouseDown()
    {
        //change scene
        if (!Locked)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            SceneManager.LoadScene(Scene);
        }
    }

    void OnMouseEnter()
    {
        if (!Locked)
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);

        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }


}
