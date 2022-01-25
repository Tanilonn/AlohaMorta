using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoraRoom : MonoBehaviour
{
    private GameManager manager;
    public int Objective;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (manager.Objectives[Objective].Completed)
        {
           
        }
    }

}
