using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessages : MonoBehaviour
{
    public MessageManager manager;
    public GameManager gameManager;

    public Button ContactPrefab;
    public Button ReplyButton;
    public Button ReplyPrefab;
    public GameObject MessagePrefab;
    public GameObject ReplyMessagePrefab;
    public Image BijlagePrefab;
    public GameObject MessageField;

    private List<Button> replies;
    private List<Image> bijlages;
    private List<Contact> contacts;
    private List<GameObject> messages;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        manager = GameObject.Find("Message Manager").GetComponent<MessageManager>();

        contacts = new List<Contact>();
        DisplayInbox();

        GetNewMessages();
        replies = new List<Button>();
        bijlages = new List<Image>();
        messages = new List<GameObject>();


        gameManager.CheckObjective(gameManager.Objectives[4]);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.NewMessagesAvailable)
        {
            GetNewMessages();
            manager.NewMessagesAvailable = false;
        }
    }

    private void GetNewMessages()
    {
        var m = manager.CheckNewMessages();
        if (m.Count > 0)
        {
            ProcessNewMessages(m);
        }
    }

    private void DisplayInbox()
    {
        foreach (var c in manager.Contacts)
        {            
            contacts.Add(c);
            DisplayContact(c);
        }
    }

    private void ProcessNewMessages(List<MessageChain> messages)
    {
        foreach (var m in messages)
        {
            m.IsReceived = true;
            DisplayUnreadContact(m);
        }
    }

    void DisplayContact(Contact c)
    {
        Color unread = new Color32(131, 166, 255, 255);

        var button = Instantiate(ContactPrefab, transform);
        button.gameObject.name = c.Name;
        button.transform.Find("Sender").GetComponent<Text>().text = c.Name;
        button.onClick.AddListener(delegate { DisplayContactChain(c); });
        button.transform.SetAsFirstSibling();
        
    }

    void DisplayUnreadContact(MessageChain m)
    {
        Color unread = new Color32(131, 166, 255, 255);

        var button = transform.Find(m.Sender).GetComponent<Button>();        
        button.onClick.AddListener(delegate { ReadMessage(button, m); });

        if (!m.IsRead)
        {
            button.image.color = unread;
        }
    }

    void ReadMessage(Button button, MessageChain m)
    {
        if (!m.IsRead)
        {
            Color read = new Color32(209, 209, 209, 255);
            Notifications.WhatsappUnread--;
            m.IsRead = true;

            button.image.color = read;
        }

    }


    void DisplayContactChain(Contact c)
    {
        HideReplies();
        HideMessages();
        foreach(var chain in c.Chains)
        {            
            if (chain.ReadObjective != 0)
            {
                gameManager.CheckObjective(gameManager.Objectives[chain.ReadObjective]);
            }
            if (chain.bijlages != null)
            {
                foreach (var b in chain.bijlages)
                {
                    var message = Instantiate(MessagePrefab, MessageField.transform);
                    messages.Add(message);
                    message.transform.Find("Panel").GetComponentInChildren<Text>().text = "bijlage";
                }
            }
            foreach(var m in chain.Messages)
            {
                var message = Instantiate(MessagePrefab, MessageField.transform);
                messages.Add(message);
                message.transform.Find("Panel").GetComponentInChildren<Text>().text = m;
            }
            //display reply if there is one
            if (chain.ChosenReply != null)
            {
                foreach (var m in chain.ChosenReply.ReplyMessages)
                {
                    var reply = Instantiate(ReplyMessagePrefab, MessageField.transform);
                    messages.Add(reply);                    
                    reply.transform.Find("Panel").GetComponentInChildren<Text>().text = m;
                }
            }
            if (AvailableReplies(chain))
            {
                var button = Instantiate(ReplyButton, MessageField.transform);
                messages.Add(button.gameObject);
                button.onClick.AddListener(delegate { DisplayReplies(chain, c); });
            }
        }        
    }


    void DisplayReplies(MessageChain m, Contact c)
    {
        HideReplies();
        foreach (var reply in manager.LoadReplies(m))
        {
            var button = Instantiate(ReplyPrefab, MessageField.transform);
            replies.Add(button);

            button.transform.Find("Text").GetComponent<Text>().text = reply.OptieNaam;
            //display reply optienaam

            button.onClick.AddListener(delegate { manager.SendReply(reply); });
            button.onClick.AddListener(delegate { HideReplies(); });
            button.onClick.AddListener(delegate { CheckReplyObjective(m, reply); });
            button.onClick.AddListener(delegate { DisplayContactChain(c); });
        }
    }

    

    private void CheckReplyObjective(MessageChain m, MessageReply r)
    {
        //set mail to replied
        m.IsReplied = true;
        m.ChosenReply = r;
        if (m.RepliedObjective != 0)
        {
            gameManager.CheckObjective(gameManager.Objectives[m.RepliedObjective]);
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


    void HideReplies()
    {
        foreach (var button in replies)
        {
            Destroy(button.gameObject);
        }
        replies.Clear();
    }

    void HideMessages()
    {
        foreach (var m in messages)
        {
            Destroy(m);
        }
        messages.Clear();
    }

    void ToggleReplyButton(bool state)
    {
        ReplyButton.gameObject.SetActive(state);
    }

    bool AvailableReplies(MessageChain m)
    {
        var replies = manager.LoadReplies(m).Count;
        if (m.IsReplied || replies == 0)
        {
            return false;
        }
        else if (!m.IsReplied && replies > 0)
        {
            return true;
        }
        return false;
    }

}
