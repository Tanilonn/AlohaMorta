using System;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleBehaviour : MonoBehaviour
{
    public Puzzle puzzle;
    public Objective Objective;
    public Canvas canvas;
    public TriggerMemory memory;
    private GameManager manager;

    private void Awake()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    public void GetObjective()
    {
        Debug.Log(puzzle.ObjectiveRef);
        Objective = manager.Objectives[puzzle.ObjectiveRef];
    }
    public void Complete()
    {
        manager.CompleteObjective(Objective);
    }

    public void StartPuzzle()
    {
        canvas.gameObject.SetActive(true);
        //set description
        GameObject.Find("Description").GetComponent<Text>().text = puzzle.Description;

        //set submit button script
        var button = GameObject.Find("SubmitButton").GetComponent<Button>();
        var inputField = GameObject.Find("InputField").GetComponent<InputField>();
        button.onClick.AddListener(delegate { CheckInput(inputField.text); });
    }

    public void EndPuzzle()
    {
        memory.SetActiveBackground(true);
        memory.OnPuzzleSolved();
        canvas.gameObject.SetActive(false);
    }

    //for Solve button
    public void CheckInput(string input)
    {
        if (input == puzzle.Solution)
        {
            Complete();
            EndPuzzle();
        }
        else
        {
            //alter canvas message
            Debug.Log("wrong" + puzzle.Solution);
        }

    }

}

