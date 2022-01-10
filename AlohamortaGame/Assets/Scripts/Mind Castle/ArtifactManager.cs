﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{
    public MemoryCanvas canvas;
    public Canvas puzzleCanvas;
    public List<GameObject> artifacts;
    public GameManager manager;


    // Start is called before the first frame update
    void Awake()
    {        
        foreach (var artifact in artifacts)
        {
            Instantiate(artifact, transform);            
        }

        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //check for first time opening
        if (!manager.Objectives[3].Completed)
        {
            manager.CompleteObjective(manager.Objectives[3]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
