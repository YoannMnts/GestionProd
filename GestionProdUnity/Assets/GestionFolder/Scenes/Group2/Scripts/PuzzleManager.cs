using UnityEngine;
using System.Linq;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [SerializeField] private MonoBehaviour[] puzzleObjects; 
    private IPuzzle[] puzzles;

    public bool allCompleted = false;

    private void Awake()
    {
        Instance = this;
        puzzles = puzzleObjects
            .Select(obj => obj.GetComponent<IPuzzle>())
            .Where(p => p != null)
            .ToArray();
        
        foreach (var puzzle in puzzles)
        {
            puzzle.OnPuzzleCompleted += CheckAllPuzzles;
        }
    }

    private void CheckAllPuzzles()
    {
        if (allCompleted) return;

        
        if (puzzles.All(p => p.IsCompleted))
        {
            allCompleted = true;
            Debug.Log("Tous les puzzles sont terminés ! Le vaisseau peut démarrer.");
        }
    }

    private void StartShip()
    {
        Debug.Log("🚀 Le vaisseau démarre !");
        
    }
}