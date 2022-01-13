﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMails : MonoBehaviour
{
    public MailManager manager;
    public GameManager gameManager;
    public Button ButtonPrefab;
    public Button ReplyButton;
    public Button ReplyPrefab;
    public Image BijlagePrefab;
    public GameObject MailTextField;
    public GameObject BijlageVeld;
    public Text MailCount;
    private List<Mail> Mails;

   
    private List<Button> replies;
    private List<Image> bijlages;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        manager = GameObject.Find("MailManager").GetComponent<MailManager>();

        Mails = manager.LoadEmails();
        MailCount.text = "Inbox (" + Notifications.MailUnread.ToString() +")";
        DisplayInbox();
        GetNewEmails();
        replies = new List<Button>();
        bijlages = new List<Image>();
        ToggleReplyButton(false);

        
        gameManager.CheckObjective(gameManager.Objectives[4]);
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.NewMailsAvailable)
        {            
            GetNewEmails();
            manager.NewMailsAvailable = false;
            MailCount.text = "Inbox (" + Notifications.MailUnread.ToString() + ")";
        }
    }

    private void GetNewEmails()
    {
        var newMail = manager.CheckNewEmails();
        if (newMail.Count > 0)
        {
            Mails = manager.LoadEmails();
            MailCount.text = "Inbox (" + Mails.Count.ToString() + ")";
            DisplayNewMails(newMail);
        }
    }

    private void DisplayInbox()
    {
        foreach(var mail in Mails)
        {
            DisplayMail(mail);
        }
    }

    private void DisplayNewMails(List<Mail> newMails)
    {
        foreach (var mail in newMails)
        {
            mail.IsReceived = true;
            DisplayMail(mail);            
        }
    }

    void DisplayMail(Mail mail)
    {
        Color unread = new Color32(131, 166, 255, 255);

        var button = Instantiate(ButtonPrefab, transform);
        button.transform.Find("Sender").GetComponent<Text>().text = mail.Sender;
        button.transform.Find("Subject").GetComponent<Text>().text = mail.Subject;
        button.transform.Find("Text").GetComponent<Text>().text = mail.Text.text.Replace(System.Environment.NewLine, "");
        button.onClick.AddListener(delegate { DisplaySelectedMail(mail); });
        button.onClick.AddListener(delegate { ReadMail(button, mail); });
        button.transform.SetAsFirstSibling();
        if (!mail.IsRead)
        {
            button.image.color = unread;
        }
    }

    void ReadMail(Button button, Mail mail)
    {
        if (!mail.IsRead)
        {
            Color read = new Color32(209, 209, 209, 255);
            Notifications.MailUnread--;
            mail.IsRead = true;

            button.image.color = read;
        }
        
    }


    void DisplaySelectedMail(Mail mail)
    {
        HideBijlages();        
        ToggleReplyButton(AvailableReplies(mail));
        
        HideReplies(replies);
        MailTextField.transform.Find("Sender").GetComponent<Text>().text = mail.Sender;
        MailTextField.transform.Find("Subject").GetComponent<Text>().text = mail.Subject;
        MailTextField.transform.Find("Text").GetComponent<Text>().text = mail.Text.text;
        if(mail.bijlages.Count > 0)
        {
            foreach (var bijlage in mail.bijlages)
            {
                var b = Instantiate(BijlagePrefab, BijlageVeld.transform);
                b.sprite = bijlage;
                bijlages.Add(b);
            }
        }
        ReplyButton.onClick.RemoveAllListeners();
        ReplyButton.onClick.AddListener(delegate { DisplayReplies(mail); });
        if (mail.ReadObjective != 0)
        {
            gameManager.CheckObjective(gameManager.Objectives[mail.ReadObjective]);
        }
    }
   

    void DisplayReplies(Mail mail)
    {
        ToggleReplyButton(false);
        replies.Clear();
        
        foreach (var reply in manager.LoadReplies(mail))
        {
            var button = Instantiate(ReplyPrefab, MailTextField.transform);
            replies.Add(button);
            button.transform.Find("Sender").GetComponent<Text>().text = "Jij";
            button.transform.Find("Subject").GetComponent<Text>().text = reply.OptieNaam;
            button.transform.Find("Text").GetComponent<Text>().text = "";


            if (reply.bijlages.Count > 0)
            {
                foreach (var bijlage in reply.bijlages)
                {
                    var b = Instantiate(BijlagePrefab, button.transform);
                    b.sprite = bijlage;                    
                }
            }
            
            button.onClick.AddListener(delegate { manager.SendReply(reply); });
            button.onClick.AddListener(delegate { HideReplies(replies); });
            button.onClick.AddListener(delegate { CheckReplyObjective(mail); });
            button.onClick.AddListener(delegate { DisplaySentReply(reply); });
            button.transform.SetAsFirstSibling();
        }
    }

    private void DisplaySentReply(Reply reply)
    {
        HideBijlages();
        ToggleReplyButton(false);

        HideReplies(replies);
        MailTextField.transform.Find("Sender").GetComponent<Text>().text = reply.Subject;
        MailTextField.transform.Find("Subject").GetComponent<Text>().text = "Net verzonden";
        MailTextField.transform.Find("Text").GetComponent<Text>().text = reply.Text.text;
        if (reply.bijlages.Count > 0)
        {
            foreach (var bijlage in reply.bijlages)
            {
                var b = Instantiate(BijlagePrefab, BijlageVeld.transform);
                b.sprite = bijlage;
                bijlages.Add(b);
            }
        }
        ReplyButton.onClick.RemoveAllListeners();
        
    }

    private void CheckReplyObjective(Mail mail)
    {
        //set mail to replied
        mail.IsReplied = true;
        if (mail.RepliedObjective != 0)
        {
            gameManager.CheckObjective(gameManager.Objectives[mail.RepliedObjective]);
        }
    }

    void HideBijlages()
    {
        foreach (var bijlage in bijlages)
        {
            Destroy(bijlage.gameObject);
        }
        bijlages.Clear();
    }


    void HideReplies(List<Button> buttons)
    {
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
        replies.Clear();
    }

    void ToggleReplyButton(bool state)
    {
        ReplyButton.gameObject.SetActive(state);
    }

    bool AvailableReplies(Mail mail)
    {
        var replies = manager.LoadReplies(mail).Count;
        if (mail.IsReplied ||  replies == 0)
        {
            return false;
        }
        else if(!mail.IsReplied && replies > 0 )
        {
            return true;
        }
        return false;
    }

}
