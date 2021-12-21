using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{

    public List<GameObject> artifacts;
    public MemoryCanvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        foreach(var artifact in artifacts)
        {
            Instantiate(artifact, transform);
            var script = artifact.gameObject.GetComponent<TriggerMemory>();
            script.canvas.canvas = canvas.canvas;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
