using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class ChasingState : EnemyBaseState
    {
        private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
        private readonly int SpeedHash = Animator.StringToHash("Speed");

        private const float CrossFadeDuration = 0.1f;
        private const float AnimatorDampTime = 0.1f;
    
        public ChasingState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
        }

        public override void Tick(float deltaTime)
        {
            if (!IsInChaseRange())
            {
                _stateMachine.SwitchState(new IdleState(_stateMachine));
                return;
            }
            else if (IsInAttackRange())
            {
                _stateMachine.SwitchState(new AttackingState(_stateMachine));
                return;
            }

            MoveToPlayer(deltaTime);
            FacePlayer();
            
            _stateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDampTime, deltaTime);
        }
        
        public override void Exit()
        {
            _stateMachine.Agent.ResetPath();
            _stateMachine.Agent.velocity = Vector3.zero;
        }
        
        private void MoveToPlayer(float deltaTime)
        {
            if (_stateMachine.Agent.isOnNavMesh)
            {
                _stateMachine.Agent.destination = _stateMachine.Player.transform.position;
                Move(_stateMachine.Agent.desiredVelocity.normalized * _stateMachine.MovementSpeed, deltaTime);
            }
            _stateMachine.Agent.velocity = _stateMachine.Controller.velocity;
        }

        private bool IsInAttackRange()
        {
            float playerDistanceSqr = (_stateMachine.Player.transform.position - _stateMachine.transform.position).sqrMagnitude;
            return playerDistanceSqr <= _stateMachine.AttackRange * _stateMachine.AttackRange;
        }
    }
}
