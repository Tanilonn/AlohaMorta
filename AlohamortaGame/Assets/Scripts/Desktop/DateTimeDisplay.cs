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
        if(DateTime.Hour < 10)
        {
            prehour = "0";
        }
        string preminute = "";
        if (DateTime.Minute < 10)
        {
            preminute = "0";
        }
        displayDateTime.text = prehour + DateTime.Hour.ToString() + ":" + preminute + DateTime.Minute.ToString() + "\n" + "0" + DateTime.Day.ToString() + "-" + DateTime.month.ToString() + "-" + DateTime.year.ToString();
        bigDate.text = "0" +DateTime.Day.ToString() + "-" + DateTime.month.ToString() + "-" + DateTime.year.ToString();
        bigTime.text = prehour + DateTime.Hour.ToString() + ":" + preminute + DateTime.Minute.ToString();
    }
}
