using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public string Name;
    public string Description;
    public string Solution;
    public int ObjectiveRef;
    public Objective objective { get; private set; }

    private void Start()
    {
        GameManager manager = GameObject.Find("Manager").GetComponentInChildren<GameManager>();
        objective = manager.Objectives[ObjectiveRef];
    }
    public void Complete()
    {
        objective.Completed = true;

    }

}

