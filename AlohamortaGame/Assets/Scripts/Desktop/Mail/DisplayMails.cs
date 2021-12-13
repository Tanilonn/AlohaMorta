using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMails : MonoBehaviour
{
    public MailManager manager;
    public Button ButtonPrefab;
    public Text MailTextField;
    public Text MailCount;
    private List<Mail> Mails;

    // Start is called before the first frame update
    void Start()
    {
        Mails = manager.LoadEmails();
        MailCount.text = "Inbox (" + Mails.Count.ToString() + ")";
        DisplayInbox();

    }

    // Update is called once per frame
    void Update()
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
        MailTextField.text = mail.Text.text;
        mail.IsRead = true;
    }
}
