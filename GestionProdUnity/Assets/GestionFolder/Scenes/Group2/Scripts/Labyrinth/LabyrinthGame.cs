using UnityEngine;
using UnityEngine.EventSystems;

public class LabyrinthGame : MonoBehaviour, IPuzzle
{
    public RectTransform startPoint;
    public RectTransform endPoint;
    public bool IsCompleted { get; private set; }
    public event System.Action OnPuzzleCompleted;
    private bool started = false;

    public void OnPointerEnterStart()
    {
        started = true;
    }

    public void OnPointerEnterEnd()
    {
        if (started)
        {
            Debug.Log("Labyrinthe terminé !");
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CompletePuzzle();
        }
    }

    public void OnPointerExitPath()
    {
        if (started)
        {
            Debug.Log("Sorti du chemin !");
            started = false;
        }
    }
    public void CompletePuzzle()
    {
        if (IsCompleted) return;

        IsCompleted = true;
        Debug.Log(name + " est terminé !");
        OnPuzzleCompleted?.Invoke();
    }
}