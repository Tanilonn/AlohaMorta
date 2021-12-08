using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMemory : MonoBehaviour
{
    public GameObject canvas;
    public Memory memory;

    public Text title;
    public Text text;
    public Image image;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        canvas.SetActive(true);
        transform.root.gameObject.SetActive(false);
        title.text = memory.Title;
        text.text = memory.Text;
        image.sprite = memory.Image;
    }
}
