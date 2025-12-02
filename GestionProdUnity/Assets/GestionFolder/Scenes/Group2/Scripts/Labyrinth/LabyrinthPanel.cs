using CharacterController;
using UnityEngine;
using Scripts;

public class LabyrinthPanel : MonoBehaviour, Iinteractable
{
    public string InteractMessage => "Appuyez sur E pour résoudre le labyrinthe";

    [SerializeField] GameObject labyrinthUI;
    private bool active = false;
    
    [SerializeField] 
    private FPSInput fpsInput;

    public void Interact()
    {
        active = !active;
        labyrinthUI.SetActive(active);

        if (active)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fpsInput.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            fpsInput.enabled = true;
        }
    }
}

