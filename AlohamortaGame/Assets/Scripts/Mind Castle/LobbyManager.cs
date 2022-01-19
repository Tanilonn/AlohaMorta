using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private GameManager manager;
    public GameObject Textbox;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (!manager.Objectives[3].Completed)
        {
            Textbox.SetActive(true);
            manager.CheckObjective(manager.Objectives[3]);
        }
    }

}
