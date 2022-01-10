﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Objective> Objectives = new List<Objective>();
    public List<GameObject> artifacts;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
