using UnityEngine;
using Scripts; // pour IInteractable

public class CablesPanel : MonoBehaviour, Iinteractable
{
    public string InteractMessage => "Appuyez sur E pour brancher les câbles";
    
    [SerializeField] private GameObject cableUI; 

    private bool isActive = false;

    public void Interact()
    {
        isActive = !isActive;
        cableUI.SetActive(isActive);
        if (isActive)
        {
            Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}