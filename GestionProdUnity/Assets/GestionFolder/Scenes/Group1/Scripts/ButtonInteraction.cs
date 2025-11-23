using CharacterController;
using GestionFolder.Scenes.Group1.Scripts;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour, IInteractable
{
    public bool isDone { get; private set; } = false;
    [SerializeField]
    private FPSCharacter character;
    [SerializeField]
    private NoGravityZone[] noGravityZones;

    public void Interact()
    {
        character.ActivateGravity();
        foreach (var noGravityZone in noGravityZones)
        {
            noGravityZone.gameObject.SetActive(false);
        }
        isDone = true;
    }
}
