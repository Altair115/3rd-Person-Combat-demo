using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerAttackingState : PlayerBaseState
    {
        private Attack _attack;
    
        public PlayerAttackingState(PlayerStateMachine stateMachine, int attackId) : base(stateMachine)
        {
            _attack = stateMachine.Attacks[attackId];
        }

        public override void Enter()
        {
            _stateMachine.Animator.CrossFadeInFixedTime(_attack.AnimationName, .1f);
        }

        public override void Tick(float deltaTime)
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
