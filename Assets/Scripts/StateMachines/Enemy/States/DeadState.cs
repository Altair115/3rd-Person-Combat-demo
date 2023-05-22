using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class DeadState : EnemyBaseState
    {
        public DeadState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.Ragdoll.ToggleRagdoll(true);
            _stateMachine.Weapon.gameObject.SetActive(false);
            GameObject.Destroy(_stateMachine.Target);
        }

        public override void Tick(float deltaTime)
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
