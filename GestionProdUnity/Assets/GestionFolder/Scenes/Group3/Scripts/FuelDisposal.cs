using Scripts;
using UnityEngine;

public class FuelDisposal : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject player;


    public string InteractMessage => "Déposez le fuel Ici";
    public void Interact()
    {
        if(player.GetComponent<InventoryHassoul>().Fuel <= 1)
            door.SetActive(false);
    }
}
