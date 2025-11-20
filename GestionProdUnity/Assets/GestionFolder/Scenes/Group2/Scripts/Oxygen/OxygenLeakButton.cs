using UnityEngine;
using Scripts;

public class OxygenLeakButton : MonoBehaviour, Iinteractable
{
    public string InteractMessage => "Appuyez sur E pour lancer la fuite d'oxygène";

    public void Interact()
    {
        OxygenSystem.Instance.StartLeak();
    }
}