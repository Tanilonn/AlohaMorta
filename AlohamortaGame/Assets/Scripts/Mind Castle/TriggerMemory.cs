using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMemory : MonoBehaviour
{
    public MemoryCanvas canvas;
    public Memory memory;
    public Texture2D cursor;

    

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        canvas.canvas.gameObject.SetActive(true);
        transform.root.gameObject.SetActive(false);
        canvas.title.text = memory.Title;
        canvas.text.text = memory.Text;
        canvas.image.sprite = memory.Image;
        canvas.audioPlayer.clip = memory.Sound;
        canvas.audioPlayer.Play();
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
