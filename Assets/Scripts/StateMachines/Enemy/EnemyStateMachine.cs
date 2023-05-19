using StateMachines.Enemy.States;
using UnityEngine;
using UnityEngine.AI;

namespace StateMachines.Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        [field: SerializeField]public Animator Animator { get; private set; }
        [field: SerializeField]public CharacterController Controller { get; private set; }
        [field: SerializeField]public ForceReciever ForceReciever { get; private set; }
        [field: SerializeField]public NavMeshAgent Agent { get; private set; }
        [field: SerializeField]public float MovementSpeed { get; private set; }
        [field: SerializeField]public float PlayerChasingRange { get; private set; }
        [field: SerializeField]public float AttackRange { get; private set; }
        
        public GameObject Player { get; private set; }
        
        private void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Agent.updatePosition = false;
            Agent.updateRotation = false;
            SwitchState(new IdleState(this));
        }

        /// <summary>
        /// Animation event that need to be caught
        /// Trigger by the walking animations
        /// </summary>
        private void FootL()
        {
            
        }

        /// <summary>
        /// Animation event that need to be caught
        /// Trigger by the walking animations
        /// </summary>
        private void FootR()
        {
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
        }
    }
}
