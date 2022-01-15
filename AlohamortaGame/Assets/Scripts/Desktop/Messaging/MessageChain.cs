using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MessageChain
{
    public int Day;
    public int Hour;
    public string Sender;
    public List<string> Messages;
    public bool IsReceived;
    public bool IsRead;
    public bool IsReplied;
    public bool IsNotified;
    public List<MessageReply> Replies;
    public MessageReply ChosenReply;
    public Branch RequiredBranch;
    public int RequiredObjective;
    public int ReadObjective;
    public int RepliedObjective;
    public List<Sprite> bijlages;

}