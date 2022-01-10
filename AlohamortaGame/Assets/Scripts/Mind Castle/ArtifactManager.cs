﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{
    public MemoryCanvas canvas;
    public Canvas puzzleCanvas;
    public List<GameObject> artifacts;


    // Start is called before the first frame update
    void Awake()
    {        
        foreach (var artifact in artifacts)
        {
            Instantiate(artifact, transform);            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
