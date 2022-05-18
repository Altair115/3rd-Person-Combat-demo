using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerTestState : PlayerBaseState
    {
        public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            Vector3 movement = CalculateMovement();
            
            _stateMachine.Controller.Move(movement * (_stateMachine.OutOfCombatSpeed * deltaTime));

            if (_stateMachine.InputReader.MovementValue == Vector2.zero)
            {
                _stateMachine.Animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);
                return;
            }
            _stateMachine.Animator.SetFloat("FreeLookSpeed", 1, 0.1f, deltaTime);
            _stateMachine.transform.rotation = Quaternion.LookRotation(movement);
        }

        public override void Exit()
        {
            
        }

        public Vector3 CalculateMovement()
        {
            Vector3 forward = _stateMachine.MainCameraTransform.forward;
            Vector3 right = _stateMachine.MainCameraTransform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            return forward * _stateMachine.InputReader.MovementValue.y + right * _stateMachine.InputReader.MovementValue.x;
        }
    }
}
