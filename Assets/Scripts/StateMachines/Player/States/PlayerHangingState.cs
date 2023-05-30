using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerHangingState : PlayerBaseState
    {
        private readonly int HangingHash = Animator.StringToHash("Hanging");
        private const float _animatorCrossFadeDuration = 0.1f;
        private Vector3 _ledgeForward;
        
        public PlayerHangingState(PlayerStateMachine stateMachine, Vector3 ledgeForward) : base(stateMachine)
        {
            _ledgeForward = ledgeForward;
        }

        public override void Enter()
        {
            _stateMachine.transform.rotation = Quaternion.LookRotation(_ledgeForward,Vector3.up);
            _stateMachine.Animator.CrossFadeInFixedTime(HangingHash, _animatorCrossFadeDuration);
        }

        public override void Tick(float deltaTime)
        {
            if (_stateMachine.InputReader.MovementValue.y < 0f)
            {
                _stateMachine.Controller.Move(Vector3.zero);
                _stateMachine.ForceReciever.Reset();
                _stateMachine.SwitchState(new PlayerFallingState(_stateMachine));
            }
        }

        public override void Exit()
        {
            
        }
    }
}
