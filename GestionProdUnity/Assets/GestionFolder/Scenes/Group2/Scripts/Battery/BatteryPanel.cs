using CharacterController;
using UnityEngine;
using Scripts;
using UnityEngine.EventSystems;


public class BatteryPanel : MonoBehaviour, Iinteractable
{
    public string InteractMessage => isActive ? "" : "Appuyez sur E pour Remplir la batterie";
    [SerializeField]
    private GameObject cableUI;
    [SerializeField]
    private FPSInput fpsInput;

    private bool isActive = false;

    public void Interact()
    {
        isActive = !isActive;
        cableUI.SetActive(isActive);
        if (isActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fpsInput.enabled = false;
        }
        else
        {
            fpsInput.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
