using UnityEngine;
using Scripts;

public class OxygenLeakButton : MonoBehaviour, Iinteractable
{
    public string InteractMessage => interactMessage;

    [SerializeField] 
    private string interactMessage = "Oxygen Fix";
 
    public GameObject objectToDisable;
    public GameObject objectToEnable1;
    public GameObject objectToEnable2;

    public void Interact()
    {
        OxygenSystem.Instance.StartLeak();
        
        if (objectToDisable != null)
            objectToDisable.SetActive(false);
        
        if (objectToEnable1 != null)
            objectToEnable1.SetActive(true);

        if (objectToEnable2 != null)
            objectToEnable2.SetActive(true);
    }
}