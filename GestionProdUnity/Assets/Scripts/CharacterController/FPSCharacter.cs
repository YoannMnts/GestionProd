using System;
using System.Linq;
using ECM2;
using UnityEngine;

namespace CharacterController
{
    public class FPSCharacter : Character
    {
        public event Action OnGravityActivates;
        public event Action OnGravityDeactivates;
        
        [Tooltip("The first person camera parent.")]
        public GameObject cameraParent;

        private float _cameraPitch;

        public bool IsGravityActive { get; private set; }


        public void ActivateGravity()
        {
            if(IsGravityActive)
                return;

            IsGravityActive = true;
            gravityScale = 1;
            OnGravityActivates?.Invoke();
        }

        public void DeactivateGravity()
        {
            if(!IsGravityActive)
                return;
            
            IsGravityActive = false;
            gravityScale = 0;
            OnGravityDeactivates?.Invoke();
        }
        
        /// <summary>
        /// Add input (affecting Yaw).
        /// This is applied to the Character's rotation.
        /// </summary>

        public virtual void AddControlYawInput(float value)
        {
            if (value != 0.0f)
                AddYawInput(value);
        }

        /// <summary>
        /// Add input (affecting Pitch).
        /// This is applied to the cameraParent's local rotation.
        /// </summary>

        public virtual void AddControlPitchInput(float value, float minPitch = -80.0f, float maxPitch = 80.0f)
        {
            if (value != 0.0f)
                _cameraPitch = MathLib.ClampAngle(_cameraPitch + value, minPitch, maxPitch);
        }

        /// <summary>
        /// Update cameraParent local rotation applying current _cameraPitch value.
        /// </summary>

        protected virtual void UpdateCameraParentRotation()
        {
            cameraParent.transform.localRotation = Quaternion.Euler(_cameraPitch, 0.0f, 0.0f);
        }

        /// <summary>
        /// If overriden, base method MUST be called.
        /// </summary>

        protected virtual void LateUpdate()
        {
            UpdateCameraParentRotation();
        }

        /// <summary>
        /// If overriden, base method MUST be called.
        /// </summary>

        protected override void Reset()
        {
            // Call base method implementation

            base.Reset();

            // Disable character's rotation,
            // it is handled by the AddControlYawInput method 

            SetRotationMode(RotationMode.None);
        }
    }
}