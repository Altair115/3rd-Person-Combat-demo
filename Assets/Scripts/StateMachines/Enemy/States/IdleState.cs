using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class IdleState : EnemyBaseState
    {
        private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
        private readonly int SpeedHash = Animator.StringToHash("Speed");

        private const float CrossFadeDuration = 0.1f;
        private const float AnimatorDampTime = 0.1f;
    
        public IdleState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
        }

        public override void Tick(float deltaTime)
        {
            _stateMachine.Animator.SetFloat(SpeedHash, 0, AnimatorDampTime, deltaTime);
        }

        public override void Exit()
        {
        
        }
    }
}
