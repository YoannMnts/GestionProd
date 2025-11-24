using System;
using ECM2;
using ECM2.Examples;
using Extensions;
using Unity.VisualScripting;
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
        private const string DEFAULT_MAP = "Default";
        private const string NO_GRAVITY_MAP = "NoGravity";

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

        public FPSCharacter FirstPersonCharacter { get; private set; }

        /// <summary>
        /// Movement InputAction.
        /// </summary>

        public InputAction LookInputAction { get; private set; }
        public InputAction FloatingLookInputAction { get; private set; }
        public InputAction FloatingMoveInputAction { get; private set; }
        
        public InputAction InteractInputAction { get; private set; }
        public FPSCharacter FPSCharacter => character as FPSCharacter;
        
        
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
            inputActionsAsset.SetActionMaps(DEFAULT_MAP);
        }
        
        public void OnGravityDeactivates()
        {
            inputActionsAsset.SetActionMaps(NO_GRAVITY_MAP);
            //Debug.Log("Deactivated");
        }
        /// <summary>
        /// Polls look InputAction (if any).
        /// Return its current value or zero if no valid InputAction found.
        /// </summary>
        
        public Vector2 GetLookInput()
        {
            var action = FPSCharacter.IsFloating ? FloatingLookInputAction : LookInputAction;
            return action?.ReadValue<Vector2>() ?? Vector2.zero;
        }
        
        /// <summary>
        /// Initialize player InputActions (if any).
        /// E.g. Subscribe to input action events and enable input actions here.
        /// </summary>

        protected override void InitPlayerInput()
        {
            base.InitPlayerInput();
            
            // Look input action (no handler, this is polled, e.g. GetLookInput())

            LookInputAction = inputActionsAsset.FindActionMap(DEFAULT_MAP).FindAction("Look");
            InteractInputAction = inputActionsAsset.FindActionMap(DEFAULT_MAP).FindAction("Interact");
            FloatingLookInputAction = inputActionsAsset.FindActionMap(NO_GRAVITY_MAP).FindAction("Look");
            FloatingMoveInputAction = inputActionsAsset.FindActionMap(NO_GRAVITY_MAP).FindAction("Move");
            LookInputAction?.Enable();
            FloatingLookInputAction?.Enable();
            FloatingMoveInputAction?.Enable();
            
            inputActionsAsset.SetActionMaps(DEFAULT_MAP);
        }

        /// <summary>
        /// Unsubscribe from input action events and disable input actions.
        /// </summary>

        protected override void DeinitPlayerInput()
        {
            base.DeinitPlayerInput();

            // Unsubscribe from input action events and disable input actions

            LookInputAction?.Disable();
            LookInputAction = null;

            FloatingLookInputAction?.Disable();
            FloatingLookInputAction = null;
            
            FloatingMoveInputAction?.Disable();
            FloatingMoveInputAction = null;
            
            inputActionsAsset.SetActionMaps();
        }

        protected override void Awake()
        {
            base.Awake();
            
            FirstPersonCharacter = character as FPSCharacter;
        }

        protected virtual void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        protected override void HandleInput()
        {
            // Move

            if (FPSCharacter.IsFloating)
            {
                InteractInputAction?.Enable();
                Vector3 movementInput = FloatingMoveInputAction.ReadValue<Vector3>();
                
                Vector3 movementDirection = Vector3.zero;

                movementDirection += Vector3.forward * movementInput.z;
                movementDirection += Vector3.right * movementInput.x;
                movementDirection += Vector3.up * movementInput.y;
                
                movementDirection =
                    movementDirection.relativeTo(FirstPersonCharacter.cameraTransform, 
                        FirstPersonCharacter.GetUpVector());

                FPSCharacter.SetFloatingDirection(movementDirection.normalized);
            }
            else
            {
                Vector2 movementInput = GetMovementInput();

                Vector3 movementDirection = Vector3.zero;

                movementDirection += Vector3.forward * movementInput.y;
                movementDirection += Vector3.right * movementInput.x;

                movementDirection =
                    movementDirection.relativeTo(FirstPersonCharacter.cameraTransform,
                        FirstPersonCharacter.GetUpVector());

                FirstPersonCharacter.SetMovementDirection(movementDirection);
            }

            // Look

            Vector2 lookInput = GetLookInput() * sensitivity;

            FirstPersonCharacter.AddControlYawInput(lookInput.x);
            FirstPersonCharacter.AddControlPitchInput(invertLook ? -lookInput.y : lookInput.y, minPitch, maxPitch);
        }
    }
}
