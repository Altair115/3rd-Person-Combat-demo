using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerJumpingState : PlayerBaseState
    {
        private readonly int JumpHash = Animator.StringToHash("Jump");
        private Vector3 _momentum;
        private const float _animatorCrossFadeDuration = 0.1f;
        
        public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.ForceReciever.Jump(_stateMachine.JumpForce);

            _momentum = _stateMachine.Controller.velocity;
            _momentum.y = 0;
            _stateMachine.Animator.CrossFadeInFixedTime(JumpHash,_animatorCrossFadeDuration);
        }

        public override void Tick(float deltaTime)
        {
            Move(_momentum, deltaTime);

            if (_stateMachine.Controller.velocity.y <= 0)
            {
                _stateMachine.SwitchState(new PlayerFallingState(_stateMachine));
                return;
            }
            
            FaceTarget();
        }

        public override void Exit()
        {
            
        }
    }
}
