using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerPullUpState : PlayerBaseState
    {
        private readonly int PullUpHash = Animator.StringToHash("PullUp");
        private const float _animatorCrossFadeDuration = 0.1f;
        private Vector3 _offset = new Vector3(0f, 3.325f, .75f);
        
        public PlayerPullUpState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.Animator.CrossFadeInFixedTime(PullUpHash, _animatorCrossFadeDuration);
        }

        public override void Tick(float deltaTime)
        {
            if(_stateMachine.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f){return;}

            _stateMachine.Controller.enabled = false;
            _stateMachine.transform.Translate(_offset, Space.Self);
            _stateMachine.Controller.enabled = true;
            
            _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine, false));
        }

        public override void Exit()
        {
            _stateMachine.Controller.Move(Vector3.zero);
            _stateMachine.ForceReciever.Reset();
        }
    }
}