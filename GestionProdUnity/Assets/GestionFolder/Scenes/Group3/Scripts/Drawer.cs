using System;
using NUnit.Framework.Constraints;
using Scripts;
using UnityEngine;

public class Drawer : MonoBehaviour, Iinteractable
{
    public string InteractMessage => isActive ? "Appuyez sur E pour fermer" : "Appuyez sur E pour ouvrir";
    
    private Vector3 closedPosition;
    private Vector3 openPosition;
    [SerializeField] private Component OpenPoint;
    

    private bool isActive = false;
    
    public void Interact()
    {
        if (!isActive)
        {
            this.transform.position = Vector3.Lerp(closedPosition, openPosition, 1f);
            isActive = !isActive;
        }
        else if (isActive)
        {
            this.transform.position = Vector3.Lerp(openPosition, closedPosition, 1f);
            isActive = !isActive;
        }
        
        
    }

    private void Awake()
    {
        closedPosition = transform.position;
        openPosition = OpenPoint.transform.position;
    }
}
