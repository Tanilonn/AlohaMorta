using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMemory : MonoBehaviour
{
    public ArtifactManager manager;
    public Memory memory;
    public Texture2D cursor;
    public Puzzle puzzle;
    private PuzzleBehaviour puzzleScript;

    private void Awake()
    {
        manager = GetComponentInParent<ArtifactManager>();
        if(!string.IsNullOrWhiteSpace(puzzle.Name))
        {
            puzzleScript = gameObject.AddComponent<PuzzleBehaviour>();
            puzzleScript.puzzle = puzzle;
            puzzleScript.canvas = manager.puzzleCanvas;
            puzzleScript.GetObjective();
            puzzleScript.memory = this;
        }
       
}

    void OnMouseDown()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        if(puzzleScript != null)
        {
            if (!puzzleScript.Objective.Completed)
            {
                StartPuzzle();
            }
            else
            {
                OpenMemory();
            }
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
        transform.root.gameObject.SetActive(false);
        puzzleScript.StartPuzzle();
    }

    void OpenMemory()
    {
        manager.canvas.canvas.gameObject.SetActive(true);
        SetActiveBackground(false);
        manager.canvas.title.text = memory.Title;
        manager.canvas.text.text = memory.Text;
        manager.canvas.image.sprite = memory.Image;
        manager.canvas.audioPlayer.clip = memory.Sound;
        manager.canvas.audioPlayer.Play();
    }

    public void OnPuzzleSolved()
    {
        if (puzzleScript.Objective.Completed)
        {
            OpenMemory();
        }
    }

    public void SetActiveBackground(bool active)
    {
        transform.root.gameObject.SetActive(active);

    }


}
