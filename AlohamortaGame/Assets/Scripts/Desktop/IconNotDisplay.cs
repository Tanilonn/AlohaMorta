using UnityEngine;
using UnityEngine.UI;

public class IconNotDisplay : MonoBehaviour
{
    public GameObject MailNot;

    void Update()
    {
        DisplayMail();
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


}
