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


    private void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (UnlockObjective != 0 && manager.Objectives[UnlockObjective].Completed)
        {
            Debug.Log(manager.Objectives[UnlockObjective].Name);
            Unlock();
        }
    }

    private void Unlock()
    {
        Locked = false;        
        door.sprite = unlocked;
        door.flipX = true;

    }

    private void OnMouseDown()
    {
        //change scene
        if (!Locked)
        {
            SceneManager.LoadScene(Scene);
        }
    }


}
