using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private Camera camera;

        [SerializeField] private TextMeshProUGUI text;

        [SerializeField] private float distance = 5f;

        Iinteractable currentInteraction;


        private void Update()
        {
            UpdateCurrentInteraction();

            UpdateInteractionText();

            CheckForInteractionInput();

        }

        private void UpdateCurrentInteraction()
        {
            var ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            Physics.Raycast(ray, out RaycastHit hit, distance);

            currentInteraction = hit.collider ? hit.collider.GetComponent<Iinteractable>() : null;
        }

        private void UpdateInteractionText()
        {
            if (currentInteraction == null)
            {
                text.text = String.Empty;
                return;
            }

            text.text = currentInteraction.InteractMessage;
        }

        void CheckForInteractionInput()
        {
            if (Input.GetKeyDown(KeyCode.E) && currentInteraction != null)
            {
                currentInteraction.Interact();
            }
        }
    }
}