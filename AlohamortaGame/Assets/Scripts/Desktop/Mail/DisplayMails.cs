using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMails : MonoBehaviour
{
    public MailManager manager;
    public Button ButtonPrefab;
    public Button ReplyButton;
    public Button ReplyPrefab;
    public GameObject MailTextField;
    public Text MailCount;
    private List<Mail> Mails;

    private int lastHour;
    private List<Button> replies;

    // Start is called before the first frame update
    void Start()
    {
        Mails = manager.LoadEmails();
        GetNewEmails();
        MailCount.text = "Inbox (" + Mails.Count.ToString() + ")";
        DisplayInbox();
        replies = new List<Button>();
        ToggleReplyButton(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(DesktopDateTime.Hour != lastHour)
        {
            lastHour = DesktopDateTime.Hour;
            GetNewEmails();
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
            var button = Instantiate(ButtonPrefab, new Vector2(ButtonPrefab.transform.position.x, ButtonPrefab.transform.position.y), Quaternion.identity, transform.parent);
            button.GetComponentInChildren<Text>().text = mail.Subject;
            button.onClick.AddListener(delegate { DisplaySelectedMail(mail); });
            button.transform.SetAsFirstSibling();
        }
    }

    private void DisplayNewMails(List<Mail> newMails)
    {
        foreach (var mail in newMails)
        {
            var button = Instantiate(ButtonPrefab, transform);
            button.transform.Find("Sender").GetComponent<Text>().text = mail.Sender;
            button.transform.Find("Subject").GetComponent<Text>().text = mail.Subject;
            button.transform.Find("Text").GetComponent<Text>().text = mail.Text.text.Replace(System.Environment.NewLine, "");
            button.onClick.AddListener(delegate { DisplaySelectedMail(mail); });
            button.transform.SetAsFirstSibling();
        }
    }


    void DisplaySelectedMail(Mail mail)
    {
        ToggleReplyButton(true);
        HideReplies(replies);
        MailTextField.transform.Find("Sender").GetComponent<Text>().text = mail.Sender;
        MailTextField.transform.Find("Subject").GetComponent<Text>().text = mail.Subject;
        MailTextField.transform.Find("Text").GetComponent<Text>().text = mail.Text.text;
        ReplyButton.onClick.RemoveAllListeners();
        ReplyButton.onClick.AddListener(delegate { DisplayReplies(mail); });
        mail.IsRead = true;
    }

    void DisplayReplies(Mail mail)
    {
        ToggleReplyButton(false);
        replies.Clear();
        
        foreach (var reply in manager.LoadReplies(mail))
        {
            var button = Instantiate(ReplyPrefab, MailTextField.transform);
            replies.Add(button);
            button.transform.Find("Subject").GetComponent<Text>().text = reply.Subject;
            button.onClick.AddListener(delegate { manager.SendReply(reply); });
            button.onClick.AddListener(delegate { HideReplies(replies); });
            button.transform.SetAsFirstSibling();
        }
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

}
