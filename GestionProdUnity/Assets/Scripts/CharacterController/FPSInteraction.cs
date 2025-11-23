using System;
using GestionFolder.Scenes.Group1.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterController
{
    public class FPSInteraction : MonoBehaviour
    {
        private IInteractable currentInteractable;
        [SerializeField]
        private FPSInput fpsInput;

        public void playerInteract(InputAction.CallbackContext context)
        {
            /*
            Debug.Log($"Player interact: {context.performed}");
            Debug.Log("currentInteractable:" + currentInteractable);
            Debug.Log("is done:" + currentInteractable.isDone);
            */
            if (context.performed && currentInteractable != null && !currentInteractable.isDone)
            {
                currentInteractable.Interact();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            /*
            Debug.Log($"OnTriggerEnter: {other}");
            Debug.Log("is IInteractable" + other.TryGetComponent<IInteractable>(out var t) + "interactable : " + t);
            */
            if (other.TryGetComponent<IInteractable>(out var interactable))
            {
                currentInteractable = interactable;
                fpsInput.InteractInputAction.performed += playerInteract;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IInteractable>(out var interactable))
            {
                currentInteractable = null;
                fpsInput.InteractInputAction.performed -= playerInteract;
            }
        }
    }
}