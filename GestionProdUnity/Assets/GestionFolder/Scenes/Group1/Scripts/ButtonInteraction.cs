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
    [SerializeField]
    private GameObject[] spawnGO;
    [SerializeField]
    private GameObject[] gravityGO;

    public void Interact()
    {
        Debug.Log("aaaa");
        character.ActivateGravity();
        foreach (var noGravityZone in noGravityZones)
        {
            noGravityZone.gameObject.SetActive(false);
        }

        foreach (var gameObject in spawnGO)
        {
            gameObject.SetActive(true);
        }
        /*
        foreach (var gameObject in gravityGO)
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }
        */
        isDone = true;
    }
}
