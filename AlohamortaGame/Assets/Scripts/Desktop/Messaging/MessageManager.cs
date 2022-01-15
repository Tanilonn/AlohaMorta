using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public List<Contact> Contacts;

    public static MessageManager Instance;

    public bool NewMessagesAvailable;

    private GameManager manager;

    private int lastHour;
    private int lastDay;

    private void Awake()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void Update()
    {
        if (DesktopDateTime.Hour != lastHour || DesktopDateTime.Day != lastDay)
        {
            lastDay = DesktopDateTime.Day;
            lastHour = DesktopDateTime.Hour;
            CheckNewMessages();
        }
    }


    public List<MessageChain> CheckNewMessages()
    {
        var newMessage = new List<MessageChain>();
        foreach (var contact in Contacts)
        {
            foreach(var m in contact.Chains)
            {            
                if (((m.Day == DesktopDateTime.Day && m.Hour <= DesktopDateTime.Hour) || (m.Day < DesktopDateTime.Day)) && !m.IsReceived)
                {
                    if (ChainAvailable(m))
                    {
                        newMessage.Add(m);
                        NewMessagesAvailable = true;
                        if (!m.IsNotified)
                        {
                            m.IsNotified = true;
                            Notifications.WhatsappUnread++;
                            StartCoroutine(manager.NotificationCoroutine("Nieuw bericht van " + m.Sender, 1));
                        }
                    }
                }
            }
        }
        return newMessage;
    }

    public List<MessageChain> CheckNewMessages(Contact c)
    {
        var newMessage = new List<MessageChain>();
        
            foreach (var m in c.Chains)
            {
                if (((m.Day == DesktopDateTime.Day && m.Hour <= DesktopDateTime.Hour) || (m.Day < DesktopDateTime.Day)) && !m.IsReceived)
                {
                    if (ChainAvailable(m))
                    {
                        newMessage.Add(m);
                        NewMessagesAvailable = true;
                        if (!m.IsNotified)
                        {
                            m.IsNotified = true;
                            Notifications.WhatsappUnread++;
                            StartCoroutine(manager.NotificationCoroutine("Nieuw bericht van " + m.Sender, 1));
                        }
                    }
                }
            }
        
        return newMessage;
    }

    public bool ChainAvailable(MessageChain chain)
    {
        if ((chain.RequiredBranch == Branch.none || Story.Branches.Contains(chain.RequiredBranch)) &&
            (chain.RequiredObjective == 0 || manager.Objectives[chain.RequiredObjective].Completed))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<MessageChain> LoadMessages()
    {
        var messages = new List<MessageChain>();
        foreach(Contact c in Contacts)
        {
            foreach(var m in c.Chains.FindAll(m => m.IsReceived == true))
            {
                messages.Add(m);
            }
        }
        return messages;
    }

    public List<MessageChain> LoadMessages(Contact c)
    {
        var messages = new List<MessageChain>();
            foreach (var m in c.Chains.FindAll(m => m.IsReceived == true))
            {
                messages.Add(m);
            }
        
        return messages;
    }

    public List<MessageReply> LoadReplies(MessageChain chain)
    {
        List<MessageReply> availableReplies = new List<MessageReply>();
        foreach (var reply in chain.Replies)
        {
            if (reply.RequiredNode == Branch.none)
            {
                availableReplies.Add(reply);
            }
            else if (Story.Branches.Contains(reply.RequiredNode))
            {
                availableReplies.Add(reply);
            }
        }
        return availableReplies;

    }

    public void SendReply(MessageReply reply)
    {
        foreach (var branch in reply.ActivatesNodes)
        {
            Story.Branches.Add(branch);
        }
        if (CheckNewMessages().Count > 0)
        {
            //if you want everything to update right away check for new emails here too!
            NewMessagesAvailable = true;
        }
    }




}
