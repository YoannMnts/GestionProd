using System;
using CharacterController;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SwitchSceneDebug : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActionsAsset;
    
    private InputAction debugAction1;
    private InputAction debugAction2;
    private InputAction debugAction3;
    

    private void Start()
    {
        
        debugAction1 = inputActionsAsset.FindActionMap("Default").FindAction("Debug");
        debugAction2 = inputActionsAsset.FindActionMap("Default").FindAction("Debug1");
        debugAction3 = inputActionsAsset.FindActionMap("Default").FindAction("Debug2");
    }

    private void FixedUpdate()
    {
        var wantSwitch = debugAction1.ReadValue<float>() != 0 || debugAction2.ReadValue<float>() != 0 || debugAction3.ReadValue<float>() != 0;
        var debug1 = (int)debugAction1.ReadValue<float>() == 1 ;
        var debug2 = (int)debugAction2.ReadValue<float>() == 1 ? 1 : 0;
        var debug3 = (int)debugAction3.ReadValue<float>() == 1 ? 2 : 0;
        var sceneToLoad = debug1 ? 0 :Mathf.Clamp((debug2 + debug3), 0, 2);
        if (wantSwitch)
        {
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log($"SceneToLoad: {sceneToLoad}");
        }
    }
}
