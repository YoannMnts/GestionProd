using UnityEngine;
using Scripts;

public class OxygenFixButton : MonoBehaviour, Iinteractable
{
   
    public string InteractMessage => interactMessage;

    [SerializeField] 
    private string interactMessage = "Oxygen Fix";
    
    public GameObject objectToEnable;
    public GameObject objectToEnable1;
    public GameObject objectToEnable2;
    public void Interact()
    {
        OxygenSystem.Instance.FixLeak();
        
        if (objectToEnable != null)
            objectToEnable.SetActive(true);

        
        if (objectToEnable1 != null)
            objectToEnable1.SetActive(true);

        if (objectToEnable2 != null)
            objectToEnable2.SetActive(true);
    }
}