using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MessageChain
{
    public int Day;
    public int Hour;
    [HideInInspector]
    public string Sender;
    public List<string> Messages;
    [HideInInspector]
    public bool IsReceived;
    [HideInInspector]
    public bool IsRead;
    [HideInInspector]
    public bool IsReplied;
    [HideInInspector]
    public bool IsNotified;
    public List<MessageReply> Replies;
    [HideInInspector]
    public MessageReply ChosenReply;
    public Branch RequiredBranch;
    public int RequiredObjective;
    public int ReadObjective;
    public int RepliedObjective;
    [HideInInspector]
    public List<Sprite> bijlages;

}