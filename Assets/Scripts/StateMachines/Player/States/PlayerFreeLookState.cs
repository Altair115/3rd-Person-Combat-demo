using System;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

namespace StateMachines.Player.States
{
    public class PlayerFreeLookState : PlayerBaseState
    {
        private readonly int freeLookBlendTreedHash = Animator.StringToHash("FreeLookBlendTree");
        private readonly int freeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
        
        private const float _animatorDampTime = 0.1f;
        private const float _animatorCrossFadeDuration = 0.1f;
        
        public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.InputReader.TargetEvent += OnTarget;
            _stateMachine.InputReader.OnJumpEvent += OnJump;
            _stateMachine.Animator.CrossFadeInFixedTime(freeLookBlendTreedHash, _animatorCrossFadeDuration);
        }
        
        public override void Tick(float deltaTime)
        {
            if (_stateMachine.InputReader.IsAttacking)
            {
                _stateMachine.SwitchState(new PlayerAttackingState(_stateMachine, 0));
                return;
            }
            
            Vector3 movement = CalculateMovement();
            
            Move(movement * _stateMachine.FreeLookMovementSpeed, deltaTime);

            if (_stateMachine.InputReader.MovementValue == Vector2.zero)
            {
                _stateMachine.Animator.SetFloat(freeLookSpeedHash, 0, _animatorDampTime, deltaTime);
                return;
            }
            _stateMachine.Animator.SetFloat(freeLookSpeedHash, 1, _animatorDampTime, deltaTime);
            FaceMovementDirection(movement, deltaTime);
        }
        
        public override void Exit()
        {
            _stateMachine.InputReader.TargetEvent -= OnTarget;
            _stateMachine.InputReader.OnJumpEvent -= OnJump;
        }
        
        private void OnTarget()
        {
            if(!_stateMachine.Targeter.SelectTarget()){return;}
            
            _stateMachine.SwitchState(new PlayerTargetingState(_stateMachine));
        }
        
        private void OnJump()
        {
            _stateMachine.SwitchState(new PlayerJumpingState(_stateMachine));
        }


        private Vector3 CalculateMovement()
        {
            Vector3 forward = _stateMachine.MainCameraTransform.forward;
            Vector3 right = _stateMachine.MainCameraTransform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            return forward * _stateMachine.InputReader.MovementValue.y + right * _stateMachine.InputReader.MovementValue.x;
        }
        
        private void FaceMovementDirection(Vector3 movement, float deltaTime)
        {
            _stateMachine.transform.rotation = Quaternion.Lerp(_stateMachine.transform.rotation, Quaternion.LookRotation(movement), deltaTime * _stateMachine.RotationDampingValue); 
        }
    }
}
