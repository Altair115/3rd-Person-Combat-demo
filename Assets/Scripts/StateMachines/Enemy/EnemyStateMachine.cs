using Combat;
using Combat.Targeting;
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
        [field: SerializeField]public WeaponDamage Weapon { get; private set; }
        [field: SerializeField]public Health Health { get; private set; }
        [field: SerializeField]public Target Target { get; private set; }
        [field: SerializeField]public Ragdoll Ragdoll { get; private set; }
        [field: SerializeField]public float MovementSpeed { get; private set; }
        [field: SerializeField]public float PlayerChasingRange { get; private set; }
        [field: SerializeField]public float AttackRange { get; private set; }
        [field: SerializeField]public int AttackDamage { get; private set; }
        [field: SerializeField]public float AttackKnockback { get; private set; }
        
        public Health Player { get; private set; }
        
        private void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            Agent.updatePosition = false;
            Agent.updateRotation = false;
            SwitchState(new IdleState(this));
        }

        private void OnEnable()
        {
            Health.OnTakeDamage += HandleOnTakeDamage;
            Health.OnDie += HandleOnDie;
        }
        
        private void OnDisable()
        {
            Health.OnTakeDamage -= HandleOnTakeDamage;
            Health.OnDie -= HandleOnDie;
        }
        
        private void HandleOnTakeDamage()
        {
            SwitchState(new ImpactState(this));
        }
        
        private void HandleOnDie()
        {
            SwitchState(new DeadState(this));
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
