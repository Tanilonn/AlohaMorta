using UnityEngine;

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
        DesktopDateTime.Day = 1;
        DesktopDateTime.Hour = 9;
    }

    private void Start()
    {
        InvokeRepeating("AddMinute", 0f, 1f);
    }

    public void NextDay()
    {
        DesktopDateTime.Day++;
        DesktopDateTime.Hour = 9;
        if (DesktopDateTime.Day >= 6)
        {
            EndGame();
        }
    }

    public void AddMinute()
    {
        if(DesktopDateTime.Minute == 59)
        {
            DesktopDateTime.Minute = 0;
            DesktopDateTime.Hour++;
            if(DesktopDateTime.Hour >= 23)
            {
                NextDay();
            }
        }
        else
        {
            DesktopDateTime.Minute++;
        }
    }

    public void EndGame()
    {
        SceneChanger scene = FindObjectOfType<SceneChanger>();
        scene.ChangeScene("End");
    }

    
}
