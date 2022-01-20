using System;
using UnityEngine;

[Serializable]
public class Memory
{
    public string name;
    public string Title;
    [TextArea]
    public string Text;
    public Sprite Image;
    public AudioClip Sound;
    public string noraComment;
}

