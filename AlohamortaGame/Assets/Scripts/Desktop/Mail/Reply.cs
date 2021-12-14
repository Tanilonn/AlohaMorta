using System;
using UnityEngine;
[Serializable]
public class Reply
{    
    public string Subject;
    public TextAsset Text;
    public Branch RequiredNode;
    public Branch ActivatesNode;   

}