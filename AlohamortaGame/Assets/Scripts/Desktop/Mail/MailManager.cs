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
                //notification
                newMail.Add(mail);
            }
        }
        return newMail;
    }

    public List<Mail> LoadEmails()
    {
        return Mails.FindAll(m => m.IsReceived == true);
    }




}
