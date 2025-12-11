using UnityEngine;
using UnityEngine.EventSystems;

public class Cable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPuzzle
{
    public RectTransform startPoint;
    public RectTransform endPoint;
    private RectTransform rect;
    private Vector2 originalPosition;

    public bool connected = false;
    public bool IsCompleted { get; private set; }
    public event System.Action OnPuzzleCompleted;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        originalPosition = rect.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        connected = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector2.Distance(rect.position, endPoint.position);
        if (distance < 50f) 
        {
            rect.position = endPoint.position;
            connected = true;
            CompletePuzzle();
        }
        else
        {
            rect.anchoredPosition = originalPosition;
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