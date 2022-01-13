using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    public List<Mail> Mails;

    public static MailManager Instance;

    public bool NewMailsAvailable;

    private GameManager manager;

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


    public List<Mail> CheckNewEmails()
    {
        var newMail = new List<Mail>();
        foreach(var mail in Mails)
        {
            if(((mail.Day == DesktopDateTime.Day && mail.Hour <= DesktopDateTime.Hour) || (mail.Day < DesktopDateTime.Day)) && !mail.IsReceived)
            {
                if (EmailAvailable(mail))
                {
                    newMail.Add(mail);
                    StartCoroutine(manager.NotificationCoroutine("Nieuwe email van " + mail.Sender + " betreft: " + mail.Subject, 1));
                }
            }
        }
        return newMail;
    }

    public bool EmailAvailable(Mail mail)
    {
        if ((mail.RequiredBranch == Branch.none || Story.Branches.Contains(mail.RequiredBranch)) &&
            (mail.RequiredObjective == 0 || manager.Objectives[mail.RequiredObjective].Completed))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Mail> LoadEmails()
    {
        return Mails.FindAll(m => m.IsReceived == true);
    }

    public List<Reply> LoadReplies(Mail mail)
    {
        List<Reply> availableReplies = new List<Reply>();
        foreach (var reply in mail.Replies)
        {
            if(reply.RequiredNode == Branch.none)
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

    public void SendReply(Reply reply)
    {
        foreach(var branch in reply.ActivatesNodes)
        {
            Story.Branches.Add(branch);
        }
        if (CheckNewEmails().Count > 0)
        {
            NewMailsAvailable = true;
        }
    }




}
