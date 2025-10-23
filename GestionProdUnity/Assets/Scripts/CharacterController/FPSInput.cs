using System;
using ECM2;
using ECM2.Examples;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

namespace CharacterController
{
    /// <summary>
    /// First person character input.
    /// Extends the default CharacterInput component adding support for typical first person controls.
    /// </summary>
    
    public class FPSInput : CharacterInput
    {
        [Space(15.0f)]
        public bool invertLook = true;
        [Tooltip("Look sensitivity")]
        public Vector2 sensitivity = new Vector2(0.05f, 0.05f);
        
        [Space(15.0f)]
        [Tooltip("How far in degrees can you move the camera down.")]
        public float minPitch = -80.0f;
        [Tooltip("How far in degrees can you move the camera up.")]
        public float maxPitch = 80.0f;
        
        /// <summary>
        /// Cached FirstPersonCharacter.
        /// </summary>

        public FPSCharacter firstPersonCharacter { get; private set; }

        /// <summary>
        /// Movement InputAction.
        /// </summary>

        public InputAction lookInputAction { get; set; }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (character is FPSCharacter fpsCharacter)
            {
                fpsCharacter.OnGravityActivates += OnGravityActivates;
                fpsCharacter.OnGravityDeactivates += OnGravityDeactivates;
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            if (character is FPSCharacter fpsCharacter)
            {
                fpsCharacter.OnGravityActivates -= OnGravityActivates;
                fpsCharacter.OnGravityDeactivates -= OnGravityDeactivates;
            }
        }

        public void OnGravityActivates()
        {
            for (int i = 0; i < inputActionsAsset.actionMaps.Count; i++)
            {
                var actionMap = inputActionsAsset.actionMaps[i];
                if(actionMap.name != "NoGravity")
                    actionMap.Enable();
                else
                    actionMap.Disable();
            }
        }
        
        public void OnGravityDeactivates()
        {
            for (int i = 0; i < inputActionsAsset.actionMaps.Count; i++)
            {
                var actionMap = inputActionsAsset.actionMaps[i];
                if(actionMap.name != "NoGravity")
                    actionMap.Enable();
                else
                    actionMap.Disable();
            }
        }
        /// <summary>
        /// Polls look InputAction (if any).
        /// Return its current value or zero if no valid InputAction found.
        /// </summary>
        
        public Vector2 GetLookInput()
        {
            return lookInputAction?.ReadValue<Vector2>() ?? Vector2.zero;
        }
        
        /// <summary>
        /// Initialize player InputActions (if any).
        /// E.g. Subscribe to input action events and enable input actions here.
        /// </summary>

        protected override void InitPlayerInput()
        {
            base.InitPlayerInput();
            
            // Look input action (no handler, this is polled, e.g. GetLookInput())

            lookInputAction = inputActionsAsset.FindAction("Look");
            lookInputAction?.Enable();
        }
        
        /// <summary>
        /// Unsubscribe from input action events and disable input actions.
        /// </summary>

        protected override void DeinitPlayerInput()
        {
            base.DeinitPlayerInput();
            
            // Unsubscribe from input action events and disable input actions

            if (lookInputAction != null)
            {
                lookInputAction.Disable();
                lookInputAction = null;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            
            firstPersonCharacter = character as FPSCharacter;
        }

        protected virtual void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        protected override void HandleInput()
        {
            // Move
            
            Vector2 movementInput = GetMovementInput();
            
            Vector3 movementDirection = Vector3.zero;
            
            movementDirection += Vector3.forward * movementInput.y;
            movementDirection += Vector3.right * movementInput.x;
            
            movementDirection = 
                movementDirection.relativeTo(firstPersonCharacter.cameraTransform, firstPersonCharacter.GetUpVector());
            
            firstPersonCharacter.SetMovementDirection(movementDirection);
            
            // Look
            
            Vector2 lookInput = GetLookInput() * sensitivity;

            firstPersonCharacter.AddControlYawInput(lookInput.x);
            firstPersonCharacter.AddControlPitchInput(invertLook ? -lookInput.y : lookInput.y, minPitch, maxPitch);
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < inputActionsAsset.actionMaps.Count; i++)
            {
                if (inputActionsAsset.actionMaps[i].enabled)
                    Debug.Log(inputActionsAsset.actionMaps[i].name);
            }
        }
    }
}
