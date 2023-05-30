using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerLandingState : PlayerBaseState
    {
        private readonly int LandHash = Animator.StringToHash("land");
        private Vector3 _momentum;
        private const float _animatorCrossFadeDuration = 0.1f;
        
        public PlayerLandingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _momentum = _stateMachine.Controller.velocity;
            _momentum.y = 0;
            _stateMachine.Animator.CrossFadeInFixedTime(LandHash, _animatorCrossFadeDuration);
        }

        public override void Tick(float deltaTime)
        {
            Move(_momentum, deltaTime);
            if (_stateMachine.Controller.isGrounded)
            {
                ReturnToLocomotion();
            }
            FaceTarget();
        }

        public override void Exit()
        {

        }
    }
}