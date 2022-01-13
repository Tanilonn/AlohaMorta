using UnityEngine;
using UnityEngine.UI;

public class IconNotDisplay : MonoBehaviour
{
    public GameObject MailNot;
    public GameObject ToDoNot;

    void Update()
    {
        DisplayMail();
        DisplayToDo();
    }

    public void DisplayMail()
    {
        if(Notifications.MailUnread == 0)
        {
            MailNot.gameObject.SetActive(false);
        }
        else
        {
            MailNot.gameObject.SetActive(true);
            MailNot.transform.Find("number").GetComponent<Text>().text = Notifications.MailUnread.ToString();

        }
    }

    public void DisplayToDo()
    {
        if (Notifications.ToDoUnread == 0)
        {
            ToDoNot.gameObject.SetActive(false);
        }
        else
        {
            ToDoNot.gameObject.SetActive(true);
            ToDoNot.transform.Find("number").GetComponent<Text>().text = Notifications.ToDoUnread.ToString();

        }
    }


}
