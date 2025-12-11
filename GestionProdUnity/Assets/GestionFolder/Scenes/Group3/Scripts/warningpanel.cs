using Scripts;
using UnityEngine;

public class warningpanel : MonoBehaviour, Iinteractable
{
    public string InteractMessage => "Le vaisseau est a cour de fuel";
    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
