using Scripts;
using UnityEngine;

public class FuelBuilder : MonoBehaviour , Iinteractable
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fuel;
    [SerializeField] private GameObject spawnPoint;
    public string InteractMessage => "E pour fabriquer le fuel";
    public void Interact()
    {
        Debug.Log("Onessaye de faire du fuel");
        if (player.GetComponent<InventoryHassoul>().RedFlower == 3 
            && player.GetComponent<InventoryHassoul>().BlueFlower == 3 
            && player.GetComponent<InventoryHassoul>().GreenFlower == 3
            && player.GetComponent<InventoryHassoul>().Tools == 1
            && player.GetComponent<InventoryHassoul>().Chemical == 2)
            Instantiate(fuel, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
