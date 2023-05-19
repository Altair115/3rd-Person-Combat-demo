using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class ImpactState : EnemyBaseState
    {
        private readonly int ImpactHash = Animator.StringToHash("Impact");
        private const float CrossFadeDuration = 0.1f;

        private float _duration = 1f;
        
        public ImpactState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.Animator.CrossFadeInFixedTime(ImpactHash,CrossFadeDuration);
        }

        public override void Tick(float deltaTime)
        {
            Move(deltaTime);
            
            _duration -= deltaTime;
            if (_duration <= 0)
            {
                _stateMachine.SwitchState(new IdleState(_stateMachine));
            }
        }

        public override void Exit()
        {
            
        }
    }
}