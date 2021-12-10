using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeDisplay : MonoBehaviour
{
    public Text displayDateTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayDateTime();

    }

    public void DisplayDateTime()
    {
        displayDateTime.text = DateTime.Hour.ToString() + ":" + DateTime.Minute.ToString() + "\n" + DateTime.Day.ToString() + "-" + DateTime.month.ToString() + "-" + DateTime.year.ToString();
    }
}
