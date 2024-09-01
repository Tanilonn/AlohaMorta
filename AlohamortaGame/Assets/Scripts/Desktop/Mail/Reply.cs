using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Reply
{    
    public string Subject;
    public string OptieNaam;
    public TextAsset Text;
    public Branch RequiredNode;
    public List<Branch> ActivatesNodes;
    public List<Sprite> bijlages;
}