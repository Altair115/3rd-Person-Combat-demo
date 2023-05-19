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

        protected void FacePlayer()
        {
            if (_stateMachine.Player == null) { return; }

            Vector3 lookPosition = _stateMachine.Player.transform.position - _stateMachine.transform.position;
            lookPosition.y = 0f;

            _stateMachine.transform.rotation = Quaternion.LookRotation(lookPosition);
        }

        protected bool IsInChaseRange()
        {
            float playerDistanceSqr = (_stateMachine.Player.transform.position - _stateMachine.transform.position).sqrMagnitude;
            return playerDistanceSqr <= _stateMachine.PlayerChasingRange * _stateMachine.PlayerChasingRange;
        }
    }
}
