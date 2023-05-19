using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class AttackingState : EnemyBaseState
    {
        private readonly int AttackHash = Animator.StringToHash("Sword-Attack-R1");
        private const float TransitionDuration = 0.1f;
        
        public AttackingState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.Weapon.SetAttack(_stateMachine.AttackDamage);
            _stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
        }

        public override void Tick(float deltaTime)
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
