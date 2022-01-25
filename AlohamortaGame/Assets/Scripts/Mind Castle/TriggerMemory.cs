using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMemory : MonoBehaviour
{
    public ArtifactManager manager;
    public Memory memory;
    public Texture2D cursor;
    public Puzzle puzzle;

    private GameManager gameManager;
    private PuzzleBehaviour puzzleScript;
    private Objective objectiveOnlyArtifact;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        manager = GetComponentInParent<ArtifactManager>();
        if(!string.IsNullOrWhiteSpace(puzzle.Name))
        {
            puzzleScript = gameObject.AddComponent<PuzzleBehaviour>();
            puzzleScript.puzzle = puzzle;
            puzzleScript.canvas = manager.puzzleCanvas;
            puzzleScript.GetObjective();
            puzzleScript.memory = this;
        }
        else if (puzzle.ObjectiveOnly)
        {
            //set private objective that is set to complete on first time opening
            objectiveOnlyArtifact = gameManager.Objectives[puzzle.ObjectiveRef];
        }
       
}

    void OnMouseDown()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        if (gameManager.NoraOpen == false)
        {
            if (puzzleScript != null)
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
        
        
    }    

    void OnMouseEnter()
    {
        if (gameManager.NoraOpen == false)
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        }
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
        //if private objective is set complete it
        if (objectiveOnlyArtifact != null)
        {
            gameManager.CheckObjective(objectiveOnlyArtifact);
        }
        manager.canvas.canvas.gameObject.SetActive(true);
        SetActiveBackground(false);
        manager.canvas.title.text = memory.Title;
        manager.canvas.text.text = memory.Text;
        manager.canvas.image.sprite = memory.Image;
        manager.canvas.image.preserveAspect = true;
        manager.canvas.audioPlayer.clip = memory.Sound;
        manager.canvas.audioPlayer.Play();
        var button = manager.canvas.canvas.gameObject.transform.Find("CloseButton").GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { CloseMemory(); });


    }

    public void CloseMemory()
    {
        if (!string.IsNullOrEmpty(memory.noraComment))
        {
            StartCoroutine(gameManager.NoraNotificationCoroutine(memory.noraComment));
        }
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
