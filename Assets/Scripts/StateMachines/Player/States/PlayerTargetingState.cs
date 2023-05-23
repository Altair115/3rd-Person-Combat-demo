using System;
using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerTargetingState : PlayerBaseState
    {
        private Vector2 _dodgingDirectionInput;
        private float _remaningDodgeTime;
        
        private readonly int targetingBlendTreedHash = Animator.StringToHash("TargetingBlendTree");
        private readonly int targetingForwardSpeedHash = Animator.StringToHash("TargetingForwardSpeed");
        private readonly int targetingRightSpeedHash = Animator.StringToHash("TargetingRightSpeed");
        
        private const float _animatorCrossFadeDuration = 0.1f;
        
        public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.InputReader.TargetEvent += OnCancel;
            _stateMachine.InputReader.DodgeEvent += OnDodge;
            _stateMachine.Animator.CrossFadeInFixedTime(targetingBlendTreedHash, _animatorCrossFadeDuration);
        }

        public override void Tick(float deltaTime)
        {
            if (_stateMachine.InputReader.IsAttacking)
            {
                _stateMachine.SwitchState(new PlayerAttackingState(_stateMachine, 0));
                return;
            }

            if (_stateMachine.InputReader.IsBlocking)
            {
                _stateMachine.SwitchState(new PlayerBlockingState(_stateMachine));
                return;
            }
            
            if (_stateMachine.Targeter.CurrentTarget == null)
            {
                _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
                return;
            }

            Vector3 movement = CalculateMovement(deltaTime);
            Move(movement * _stateMachine.TargetingMovementSpeed, deltaTime);

            UpdateAnimator(deltaTime);
            
            FaceTarget();
        }
        
        public override void Exit()
        {
            _stateMachine.InputReader.TargetEvent -= OnCancel;
            _stateMachine.InputReader.DodgeEvent -= OnDodge;
        }

        private void OnCancel()
        {
            if (_stateMachine.CurrentState != this) {return; }
            
            _stateMachine.Targeter.Cancel();
            _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
        }

        private void OnDodge()
        {
            if(Time.time - _stateMachine.PreviousDodgeTime < _stateMachine.DodgeCooldown){return;}
            
            _stateMachine.setDodgeTime(Time.time);
            _dodgingDirectionInput = _stateMachine.InputReader.MovementValue;
            _remaningDodgeTime = _stateMachine.DodgeDuration;
        }

        private Vector3 CalculateMovement(float deltaTime)
        {
            Vector3 movement = new Vector3();

            if (_remaningDodgeTime > 0f)
            {
                movement += _stateMachine.transform.right * (_dodgingDirectionInput.x * _stateMachine.DodgeDistance) /
                            _stateMachine.DodgeDuration;
                movement += _stateMachine.transform.forward * (_dodgingDirectionInput.y * _stateMachine.DodgeDistance) /
                            _stateMachine.DodgeDuration;

                _remaningDodgeTime = Mathf.Max(_remaningDodgeTime - deltaTime, 0f);
            }
            else
            {
                movement += _stateMachine.transform.right * _stateMachine.InputReader.MovementValue.x;
                movement += _stateMachine.transform.forward * _stateMachine.InputReader.MovementValue.y;
            }

            return movement;
        }
        
        private void UpdateAnimator(float deltaTime)
        {
            _stateMachine.Animator.SetFloat(targetingForwardSpeedHash, _stateMachine.InputReader.MovementValue.y, 0.1f, deltaTime);
            _stateMachine.Animator.SetFloat(targetingRightSpeedHash, _stateMachine.InputReader.MovementValue.x, 0.1f, deltaTime);
        }
    }
}
