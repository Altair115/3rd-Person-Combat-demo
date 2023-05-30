using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerDodgingState : PlayerBaseState
    {
        private readonly int dodgeBlendTreedHash = Animator.StringToHash("DodgeBlendTree");
        private readonly int dodgeForwardHash = Animator.StringToHash("DodgeForward");
        private readonly int dodgeRightHash = Animator.StringToHash("DodgeRight");
        
        private const float _animatorCrossFadeDuration = 0.1f;
        private Vector3 _dodgingDirectionInput;
        private float _remaningDodgeTime;
        
        public PlayerDodgingState(PlayerStateMachine stateMachine, Vector3 dodgingDirectionInput) : base(stateMachine)
        {
            _dodgingDirectionInput = dodgingDirectionInput;
        }

        public override void Enter()
        {
            _remaningDodgeTime = _stateMachine.DodgeDuration;
            _stateMachine.Animator.SetFloat(dodgeForwardHash, _dodgingDirectionInput.y);
            _stateMachine.Animator.SetFloat(dodgeRightHash, _dodgingDirectionInput.x);
            _stateMachine.Animator.CrossFadeInFixedTime(dodgeBlendTreedHash,_animatorCrossFadeDuration);
            _stateMachine.Health.SetInvulnerable(true);
        }

        public override void Tick(float deltaTime)
        {
            Vector3 movement = new Vector3();
            
            movement += _stateMachine.transform.right * (_dodgingDirectionInput.x * _stateMachine.DodgeDistance) /
                        _stateMachine.DodgeDuration;
            movement += _stateMachine.transform.forward * (_dodgingDirectionInput.y * _stateMachine.DodgeDistance) /
                        _stateMachine.DodgeDuration;
            
            Move(movement, deltaTime);
            FaceTarget();
            _remaningDodgeTime -= deltaTime;
            if (_remaningDodgeTime <= 0f)
            {
                _stateMachine.SwitchState(new PlayerTargetingState(_stateMachine));
            }
        }

        public override void Exit()
        {
            _stateMachine.Health.SetInvulnerable(false);
        }
    }
}
