using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerTargetingState : PlayerBaseState
    {
        private readonly int targetingBlendTreedHash = Animator.StringToHash("TargetingBlendTree");
        public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.InputReader.TargetEvent += OnCancel;
            _stateMachine.Animator.Play(targetingBlendTreedHash);
        }

        public override void Tick(float deltaTime)
        {
            if (_stateMachine.Targeter.CurrentTarget == null)
            {
                _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
                return;
            }

            Vector3 movement = CalculateMovement();
            Move(movement * _stateMachine.TargetingMovementSpeed, deltaTime);
            
            FaceTarget();
        }

        public override void Exit()
        {
            _stateMachine.InputReader.TargetEvent -= OnCancel;
        }

        private void OnCancel()
        {
            if (_stateMachine.CurrentState != this) {return; }
            
            _stateMachine.Targeter.Cancel();
            _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
        }

        private Vector3 CalculateMovement()
        {
            Vector3 movement = new Vector3();

            movement += _stateMachine.transform.right * _stateMachine.InputReader.MovementValue.x;
            movement += _stateMachine.transform.forward * _stateMachine.InputReader.MovementValue.y;
            
            return movement;
        }
    }
}
