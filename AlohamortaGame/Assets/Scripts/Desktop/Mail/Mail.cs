using System;
using UnityEngine;
[Serializable]
public class Mail
{
    public int Day;
    public int Hour;
    public string Sender; 
    public string Subject;
    public TextAsset Text;
    public bool IsReceived;
    public bool IsRead;

}