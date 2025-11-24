using UnityEngine;
using UnityEngine.EventSystems;

public class Cable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform startPoint;
    public RectTransform endPoint;
    private RectTransform rect;
    private Vector2 originalPosition;

    public bool connected = false;

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
        if (distance < 50f) // seuil pour valider la connexion
        {
            rect.position = endPoint.position;
            connected = true;
        }
        else
        {
            rect.anchoredPosition = originalPosition;
        }
    }
}