using UnityEngine;

public class InventoryHassoul : MonoBehaviour
{
    private int NbGrabbed = 0;

    // Update is called once per frame
    public void ObjectGrabbed()
    {
        NbGrabbed++;
        Debug.Log(NbGrabbed);
    }
}
