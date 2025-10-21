using System;
using ECM2;
using ECM2.Examples;
using ECM2.Examples.FirstPerson;
using UnityEngine;
using UnityEngine.InputSystem;

public class GravityCC : FirstPersonInput
{

    protected override void HandleInput()
    {
        // Move
            
        Vector2 movementInput = GetMovementInput();
            
        Vector3 movementDirection = Vector3.zero;
            
        movementDirection += Vector3.forward * movementInput.y;
        movementDirection += Vector3.right * movementInput.x;
            
        movementDirection = movementDirection.relativeTo(firstPersonCharacter.cameraTransform, firstPersonCharacter.GetUpVector());
            
        firstPersonCharacter.SetMovementDirection(movementDirection);
            
        // Look
            
        Vector2 lookInput = GetLookInput() * sensitivity;

        firstPersonCharacter.AddControlYawInput(lookInput.x);
        firstPersonCharacter.AddControlPitchInput(invertLook ? -lookInput.y : lookInput.y, minPitch, maxPitch);
    }
}
