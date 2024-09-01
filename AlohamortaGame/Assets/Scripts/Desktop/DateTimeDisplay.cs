using UnityEngine;
using UnityEngine.UI;

public class DateTimeDisplay : MonoBehaviour
{
    public Text displayDateTime;
    public Text bigTime;
    public Text bigDate;

    void Update()
    {
        DisplayDateTime();
    }

    public void DisplayDateTime()
    {
        string prehour = "";
        if(DesktopDateTime.Hour < 10)
        {
            prehour = "0";
        }
        string preminute = "";
        if (DesktopDateTime.Minute < 10)
        {
            preminute = "0";
        }
        displayDateTime.text = prehour + DesktopDateTime.Hour.ToString() + ":" + preminute + DesktopDateTime.Minute.ToString() + "\n" + "0" + DesktopDateTime.Day.ToString() + "-" + DesktopDateTime.month.ToString() + "-" + DesktopDateTime.year.ToString();
        bigDate.text = "0" +DesktopDateTime.Day.ToString() + "-" + DesktopDateTime.month.ToString() + "-" + DesktopDateTime.year.ToString();
        bigTime.text = prehour + DesktopDateTime.Hour.ToString() + ":" + preminute + DesktopDateTime.Minute.ToString();
    }
}
