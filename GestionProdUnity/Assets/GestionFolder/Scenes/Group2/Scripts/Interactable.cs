using UnityEngine;

namespace Scripts
{
    public interface Iinteractable
    {
        public string InteractMessage { get; }
        public void Interact();
    }

}

