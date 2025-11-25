using System;
using UnityEngine;

namespace Scripts
{
    public class GrabableObject : MonoBehaviour, Iinteractable
    {
        
        [SerializeField] private GameObject player;
        public string InteractMessage => "Prendre";
        public void Interact()
        {
            player.GetComponent<InventoryHassoul>().ObjectGrabbed();
        }
    }
}
