using UnityEngine;
using Scripts;

public class OxygenFixButton : MonoBehaviour, Iinteractable
{
    public string InteractMessage => "Appuyez sur E pour réparer l'oxygène";

    public void Interact()
    {
        OxygenSystem.Instance.FixLeak();
    }
}