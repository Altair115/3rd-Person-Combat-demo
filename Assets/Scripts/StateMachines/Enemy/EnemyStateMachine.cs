using StateMachines.Enemy.States;
using UnityEngine;

namespace StateMachines.Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        [field: SerializeField]public Animator Animator { get; private set; }
        
        private void Start()
        {
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
    }
}
