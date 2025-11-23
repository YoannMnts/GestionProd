using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActionsAsset;
    [SerializeField]
    private CanvasGroup debugCanvasGroup;
    private InputAction menuAction;

    private void Start()
    {
        menuAction = inputActionsAsset.FindActionMap("Default").FindAction("DebugMenu");
    }

    private void FixedUpdate()
    {
        var isDebugMenu = (int)menuAction.ReadValue<float>() == 1;
        debugCanvasGroup.alpha = isDebugMenu ? 1 : 0;
    }
}
