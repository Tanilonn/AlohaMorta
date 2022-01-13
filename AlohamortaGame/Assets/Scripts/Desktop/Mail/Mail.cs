using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Mail
{
    public string Subject;
    public int Day;
    public int Hour;
    public string Sender; 
    public TextAsset Text;
    public bool IsReceived;
    public bool IsRead;
    public bool IsReplied;
    public List<Reply> Replies;
    public Branch RequiredBranch;
    public int RequiredObjective;
    public int ReadObjective;
    public int RepliedObjective;
    public List<Sprite> bijlages;

}