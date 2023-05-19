using UnityEngine;

namespace StateMachines.Enemy
{
    public abstract class EnemyBaseState : State
    {
        protected EnemyStateMachine _stateMachine;

        public EnemyBaseState(EnemyStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        protected void Move(float deltaTime)
        {
            Move(Vector3.zero, deltaTime);
        }

        protected void Move(Vector3 motion, float deltaTime)
        {
            _stateMachine.Controller.Move((motion + _stateMachine.ForceReciever.Movement) * deltaTime);
        }

        protected bool IsInChaseRange()
        {
            float playerDistanceSqr = (_stateMachine.Player.transform.position - _stateMachine.transform.position).sqrMagnitude;
            return playerDistanceSqr <= _stateMachine.PlayerChasingRange * _stateMachine.PlayerChasingRange;
        }
    }
}
