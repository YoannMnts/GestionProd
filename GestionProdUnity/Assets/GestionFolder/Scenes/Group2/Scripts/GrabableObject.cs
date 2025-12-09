using System;
using UnityEngine;

namespace Scripts
{
    public class GrabableObject : MonoBehaviour, Iinteractable
    {
        [SerializeField] private GameObject player;
        
        [SerializeField] private String Name;
        public string InteractMessage => "Prendre"+" "+Name;
        
        private void Awake()
        {
            gameObject.name = Name;
        }

        public void Interact()
        {
            player.GetComponent<InventoryHassoul>().ObjectGrabbed(this.gameObject);
            Destroy(gameObject);
        }
    }
}
