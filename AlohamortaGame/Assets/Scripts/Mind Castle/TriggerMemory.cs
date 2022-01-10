using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMemory : MonoBehaviour
{
    public ArtifactManager manager;
    public Memory memory;
    public Texture2D cursor;
    public Puzzle puzzle;

    private void Awake()
    {
        manager = GetComponentInParent<ArtifactManager>();

    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        if(puzzle != null && puzzle.objective.Completed)
        {
            StartPuzzle();
        }
        else
        {
            OpenMemory();
        }
    }    

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void StartPuzzle()
    {
        puzzle.Complete();
        OnPuzzleComplete();
    }

    void OnPuzzleComplete()
    {
        OpenMemory();
    }

    void OpenMemory()
    {
        manager.canvas.canvas.gameObject.SetActive(true);
        transform.root.gameObject.SetActive(false);
        manager.canvas.title.text = memory.Title;
        manager.canvas.text.text = memory.Text;
        manager.canvas.image.sprite = memory.Image;
        manager.canvas.audioPlayer.clip = memory.Sound;
        manager.canvas.audioPlayer.Play();
    }


}
