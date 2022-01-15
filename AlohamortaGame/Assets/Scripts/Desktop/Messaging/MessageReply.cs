using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MessageReply
{
    public string Subject;
    public string OptieNaam;
    public List<string> ReplyMessages;
    public Branch RequiredNode;
    public List<Branch> ActivatesNodes;
    public List<Sprite> bijlages;
}