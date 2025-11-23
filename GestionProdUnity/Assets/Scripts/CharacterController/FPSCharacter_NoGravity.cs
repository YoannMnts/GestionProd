using UnityEngine;

namespace CharacterController
{
    public partial class FPSCharacter
    {
        public bool IsFloating => movementMode == MovementMode.Custom && 
                                  customMovementMode == (int)CharacterCustomMovementMode.NoGravity;


        [Header("Floating Mode")] 
        [SerializeField]
        private float floatingForce = 30;
        
        public Vector3 FloatingDirection { get; private set; }
        

        public void SetFloatingDirection(Vector3 direction)
        {
            FloatingDirection = direction;
        }
        
        protected override void OnCustomMovementMode(float deltaTime)
        {
            base.OnCustomMovementMode(deltaTime);
            switch (movementMode, (CharacterCustomMovementMode)customMovementMode)
            {
                case (MovementMode.Custom, CharacterCustomMovementMode.NoGravity):
                    DoFloatingMovementMode(deltaTime);
                    break;
            }
        }

        protected override void OnBeforeSimulationUpdate(float deltaTime)
        {
            base.OnBeforeSimulationUpdate(deltaTime);
            
            if (!IsGravityActive && !IsFloating)
                DoFloating();

            if (IsGravityActive && IsFloating)
                StopFloating();
            
            //Debug.Log($"{IsGravityActive} => {IsFloating}");
            gravityScale = IsFloating ? 0f : 1f;
        }

        public override Vector3 ConstrainInputVector(Vector3 inputVector)
        {
            if (IsFloating)
            {
                return inputVector;
            }
            
            return base.ConstrainInputVector(inputVector);
        }

        private void DoFloating()
        {
            SetMovementMode(MovementMode.Custom, (int)CharacterCustomMovementMode.NoGravity);
            EnableGroundConstraint(false);
            //AddForce(-GetGravityDirection().normalized * 5);
        }
        
        private void StopFloating()
        {
            SetMovementMode(MovementMode.Falling);
        }
        
        private void DoFloatingMovementMode(float deltaTime)
        {
            SetMovementDirection(Vector3.zero);
            AddForce(FloatingDirection * floatingForce);
        }
    }
}