using JetBrains.Annotations;
using UnityEngine;

public class InventoryHassoul : MonoBehaviour
{
    public int BlueFlower { get; private set; }
    public int RedFlower { get; private set; }
    public int GreenFlower { get; private set; }
    public int Chemical { get; private set; }
    public int Tools { get; private set; }
    public int Fuel { get; private set; }
    
    
    public void ObjectGrabbed(GameObject GrabbedObject)
    {
        
        string objectname = GrabbedObject.name;
        if (objectname == "BlueFlower")
            BlueFlower++;
        else if (objectname == "RedFlower")
            RedFlower++;
        else if (objectname == "GreenFlower")
            GreenFlower++;
        else if (objectname == "Chemical")
            Chemical++;
        else if (objectname == "Tools")
            Tools++;
        else if (objectname == "Fuel")
            Fuel++;

        Debug.Log(objectname);
    }
}
