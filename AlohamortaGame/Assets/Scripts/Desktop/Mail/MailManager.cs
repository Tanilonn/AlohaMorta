using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    public List<Mail> Mails;

    public static MailManager Instance;

    private void Awake()
    {
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
            if(mail.Day <= DesktopDateTime.Day && mail.Hour <= DesktopDateTime.Hour && !mail.IsReceived)
            {
                mail.IsReceived = true;
                if (EmailAvailable(mail))
                {
                    //notification
                    newMail.Add(mail);
                }
            }
        }
        return newMail;
    }

    public bool EmailAvailable(Mail mail)
    {
        if (mail.RequiredBranch == Branch.none || Story.Branches.Contains(mail.RequiredBranch))
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
        Story.Branches.Add(reply.ActivatesNode);
    }




}
