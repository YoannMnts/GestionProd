using System;
using UnityEngine;

namespace GestionFolder.Scenes.Group1.Scripts
{
    public class ElevatorInteraction : MonoBehaviour, IInteractable
    {
        public bool isDone { get; private set; } = false;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private GameObject elevator;
        public void Interact()
        {
            animator.enabled = true;
            isDone = true;
        }
    }
}