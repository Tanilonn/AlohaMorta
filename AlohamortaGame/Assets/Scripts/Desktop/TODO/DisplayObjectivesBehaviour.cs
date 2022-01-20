using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayObjectivesBehaviour : MonoBehaviour
{
    public Button ObjectivePrefab;
    private GameManager manager;
    public Transform Donelijst;
    public Transform TODOLijst;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        DisplayObjectives();
        Notifications.ToDoUnread = 0;
    }

   


    private void DisplayObjectives()
    {
        Color red = new Color32(224, 164, 164, 255);
        Color green = new Color32(140, 191, 154, 255);

        foreach (var objective in manager.Objectives)
        {            
            if (objective.Completed)
            {
                var obj = Instantiate(ObjectivePrefab, Donelijst);
                obj.transform.Find("Objective").GetComponent<Text>().text = objective.Name;
                obj.transform.Find("Text").GetComponent<Text>().text = objective.Description;
                obj.image.color = green;
            }
            else if (!objective.Hidden)
            {
                var obj = Instantiate(ObjectivePrefab, TODOLijst);
                obj.transform.Find("Objective").GetComponent<Text>().text = objective.Name;
                obj.transform.Find("Text").GetComponent<Text>().text = objective.Description;
                obj.image.color = red;
            }
        }
    }  
  

}
