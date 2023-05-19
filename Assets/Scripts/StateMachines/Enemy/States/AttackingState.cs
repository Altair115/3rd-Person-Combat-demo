using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class AttackingState : EnemyBaseState
    {
        private readonly int AttackHash = Animator.StringToHash("Attack 1");
        private const float TransitionDuration = 0.1f;
        
        public AttackingState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.Weapon.SetAttack(_stateMachine.AttackDamage, _stateMachine.AttackKnockback);
            _stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
        }

        public override void Tick(float deltaTime)
        {
            if (GetNormalizedTime(_stateMachine.Animator) >= 1)
            {
                _stateMachine.SwitchState(new ChasingState(_stateMachine));
            }
        }

        public override void Exit()
        {
            
        }
    }
}
