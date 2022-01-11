using System;
using System.Collections.Generic;
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
    public List<Reply> Replies;
    public Branch RequiredBranch;
    public int RequiredObjective;
    public int ReadObjective;
    public int RepliedObjective;

}