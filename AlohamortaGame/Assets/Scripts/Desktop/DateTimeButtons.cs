using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeButtons : MonoBehaviour
{
    private DateTimeManager manager;

    private void Start()
    {
        manager = GameObject.Find("DateTimeManager").GetComponent<DateTimeManager>();
    }
    public void NextDay()
    {
        DesktopDateTime.Day++;
        DesktopDateTime.Hour = 9;
        if (DesktopDateTime.Day >= 6)
        {
            manager.EndGame();
        }
    }

    public void NextTimeFrame()
    {
        if (DesktopDateTime.Hour + 5 >= 23)
        {
            NextDay();
        }
        else
        {
            DesktopDateTime.Hour += 5;
        }
    }
}
