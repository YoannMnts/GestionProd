using System;
using System.Collections;
using System.Collections.Generic;

using Scripts;
using UnityEngine;

public class Drawer : MonoBehaviour, Iinteractable
{
    public string InteractMessage => isActive ? "Appuyez sur E pour fermer" : "Appuyez sur E pour ouvrir";
    
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private float totalMovementTime = .5f;
    [SerializeField] private Component OpenPoint;
    

    private bool isActive = false;
    
    public void Interact()
    {
        if (!isActive)
        {
            StartCoroutine(openObject());
            Debug.Log("j'mouvre");
            isActive = !isActive;
        }
        else if (isActive)
        {
            StartCoroutine(closedObject());
            Debug.Log("j'me ferme");
            isActive = !isActive;
        }
        
        
    }
    
    public IEnumerator openObject() {
        float currentMovementTime = 0f;//The amount of time that has passed
        Debug.Log("je recois");
        while (Vector3.Distance(transform.localPosition, openPosition) > 0) {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(closedPosition, openPosition, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
    
    public IEnumerator closedObject() { 
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(transform.localPosition, closedPosition) > 0) {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(openPosition, closedPosition, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
    

    private void Awake()
    {
        closedPosition = transform.localPosition;
        openPosition = OpenPoint.transform.localPosition;
    }
}
