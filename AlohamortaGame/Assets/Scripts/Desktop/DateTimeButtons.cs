using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeButtons : MonoBehaviour
{
    private DateTimeManager manager;
    private GameManager gameManager;

    private void Start()
    {
        manager = GameObject.Find("DateTimeManager").GetComponent<DateTimeManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    public void NextDay()
    {
        gameManager.CheckObjective(gameManager.Objectives[8]);

        DesktopDateTime.Day++;
        DesktopDateTime.Hour = 9;
        if(DesktopDateTime.Day >= 5)
        {
            gameManager.CheckObjective(gameManager.Objectives[9]);
        }
        if (DesktopDateTime.Day >= 6)
        {
            manager.EndGame();
        }
    }

    public void NextTimeFrame()
    {
        gameManager.CheckObjective(gameManager.Objectives[7]);

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
