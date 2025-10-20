using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GravityCC : MonoBehaviour
{
    
    private PlayerInput playerInput;
    private CharacterController characterController;
    private Vector2 inputDirection;
    private float jumpInput;
    private Vector3 playerMove;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        playerMove = new Vector3(inputDirection.x, jumpInput, inputDirection.y);
        characterController.Move(playerMove);
    }

    public void MoveInputTrigger(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    public void JumpInputTrigger(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValue<float>();
    }
}
