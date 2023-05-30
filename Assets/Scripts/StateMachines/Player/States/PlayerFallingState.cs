using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerFallingState : PlayerBaseState
    {
        private readonly int FallHash = Animator.StringToHash("Fall");
        private Vector3 _momentum;
        private const float _animatorCrossFadeDuration = 0.1f;
    
        public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _momentum = _stateMachine.Controller.velocity;
            _momentum.y = 0;
            _stateMachine.Animator.CrossFadeInFixedTime(FallHash,_animatorCrossFadeDuration);
            _stateMachine.LedgeDetector.OnLedgdeDetect += HandleLedgeDetect;
        }

        public override void Tick(float deltaTime)
        {
            Move(_momentum, deltaTime);
            if (_stateMachine.Controller.isGrounded)
            {
                //_stateMachine.SwitchState(new PlayerLandingState(_stateMachine));
                ReturnToLocomotion();
            }
            FaceTarget();
        }

        public override void Exit()
        {
            _stateMachine.LedgeDetector.OnLedgdeDetect -= HandleLedgeDetect;
        }

        private void HandleLedgeDetect(Vector3 ledgeForward, Vector3 closestPoint)
        {
            _stateMachine.SwitchState(new PlayerHangingState(_stateMachine, ledgeForward, closestPoint));
            
        }
    }
}
