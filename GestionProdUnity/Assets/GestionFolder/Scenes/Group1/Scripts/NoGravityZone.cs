using CharacterController;
using ECM2.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoGravityZone : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out FPSCharacter character))
        {
            character.DeactivateGravity();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out FPSCharacter character))
        {
            character.ActivateGravity();
        }
    }
}
