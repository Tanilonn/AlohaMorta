using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{
    public MemoryCanvas canvas;
    private GameManager manager;


    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        foreach (var artifact in manager.artifacts)
        {
            Instantiate(artifact, transform);            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
