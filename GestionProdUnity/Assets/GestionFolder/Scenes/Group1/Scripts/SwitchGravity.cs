using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchGravity : MonoBehaviour
{
    private BoxCollider boxCollider;
    private PlayerInput playerInput;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInput.SwitchCurrentActionMap("NoGravity");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInput.SwitchCurrentActionMap("Default");
        }
    }
}
