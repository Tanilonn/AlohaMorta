using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Objective> Objectives = new List<Objective>();
    public List<Sprite> NotificationSprites;
    public GameObject NotificationPrefab;
    public GameObject NotificationConPrefab;
    public GameObject NoraNotifPrefab;
    private GameObject NotificationContainer;
    private GameObject NoraNotificationContainer;



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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteObjective(Objective objective)
    {
        if (!Objectives[5].Completed)
        {
            Objectives[5].Completed = true;
            Notifications.ToDoUnread++;
        }
        Notifications.ToDoUnread++;
        objective.Completed = true;
        StartCoroutine(NotificationCoroutine("Je hebt een doel voltooid: " + objective.Name + "!", 0));
    }

    public IEnumerator NotificationCoroutine(string notification, int sprite)
    {
        Canvas canvas = (Canvas)FindObjectOfType(typeof(Canvas));
        if (canvas != null)
        {
            if(NotificationContainer == null)
            {
                NotificationContainer = Instantiate(NotificationConPrefab, canvas.transform);
            }
            var n = Instantiate(NotificationPrefab, NotificationContainer.transform);
            n.transform.Find("Text").GetComponent<Text>().text = notification;
            n.transform.Find("Icon").GetComponent<Image>().sprite = NotificationSprites[sprite];

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(5);
            
            Destroy(n);           
        }        
    }

    public IEnumerator NoraNotificationCoroutine(string notification)
    {
        Canvas canvas = (Canvas)FindObjectOfType(typeof(Canvas));
        if (canvas != null)
        {
            if (NoraNotificationContainer == null)
            {
                NoraNotificationContainer = Instantiate(NoraNotifPrefab, canvas.transform);
            }
            var n = Instantiate(NotificationPrefab, NoraNotificationContainer.transform);
            n.transform.Find("Text").GetComponent<Text>().text = notification;
            n.transform.Find("Icon").GetComponent<Image>().sprite = null;

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(20);

            Destroy(n);
        }
    }

    public void CheckObjective(Objective objective)
    {
        if (!objective.Completed)
        {
            CompleteObjective(objective);
        }
    }
}
