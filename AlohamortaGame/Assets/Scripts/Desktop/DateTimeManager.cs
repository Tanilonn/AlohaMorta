using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeManager : MonoBehaviour
{
    public static DateTimeManager Instance;

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
        DateTime.Day = 1;
        DateTime.Hour = 9;
    }

    private void Start()
    {
        CancelInvoke();
        InvokeRepeating("AddMinute", 0f, 1f);
    }


    public void NextDay()
    {
        DateTime.Day++;
        DateTime.Hour = 9;
        if(DateTime.Day >= 6)
        {
            EndGame();
        }
    }

    public void NextTimeFrame()
    {
        //morning = 9, afternoon = 15, night = 21
        if (DateTime.Hour + 6 >= 23)
        {
            NextDay();
        }
        else
        {
            DateTime.Hour += 6;
        }
    }

    public void AddMinute()
    {
        if(DateTime.Minute == 59)
        {
            DateTime.Minute = 0;
            DateTime.Hour++;
            if(DateTime.Hour >= 23)
            {
                NextDay();
            }
        }
        else
        {
            DateTime.Minute++;
        }
    }

    private void EndGame()
    {
        SceneChanger scene = FindObjectOfType<SceneChanger>();
        scene.ChangeScene("End");
    }

    
}
