using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Contact
{
    public string Name;
    public string Number;
    public Sprite Photo;
    public List<MessageChain> Chains;
}