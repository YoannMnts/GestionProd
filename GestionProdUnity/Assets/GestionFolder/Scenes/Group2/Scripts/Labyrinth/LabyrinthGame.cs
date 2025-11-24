using UnityEngine;
using UnityEngine.EventSystems;

public class LabyrinthGame : MonoBehaviour
{
    public RectTransform startPoint;
    public RectTransform endPoint;

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
}