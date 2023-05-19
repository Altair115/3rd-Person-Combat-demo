using Combat;
using Combat.Targeting;
using StateMachines.Player.States;
using UnityEngine;

namespace StateMachines.Player
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField]public InputReader InputReader { get; private set; }
        [field: SerializeField]public CharacterController Controller { get; private set; }
        [field: SerializeField]public Animator Animator { get; private set; }
        [field: SerializeField]public Targeter Targeter { get; private set; }
        [field: SerializeField]public ForceReciever ForceReciever { get; private set; }
        [field: SerializeField]public WeaponDamage Weapon { get; private set; }
        [field: SerializeField]public Health Health { get; private set; }
        [field: SerializeField]public float FreeLookMovementSpeed { get; private set; }
        [field: SerializeField]public float TargetingMovementSpeed { get; private set; }
        [field: SerializeField]public float RotationDampingValue { get; private set; }
        [field: SerializeField]public Attack[] Attacks { get; private set; }
        public Transform MainCameraTransform { get; private set; }

        private void Start()
        {
            MainCameraTransform = Camera.main.transform;
            SwitchState(new PlayerFreeLookState(this));
        }
        
        private void OnEnable()
        {
            Health.OnTakeDamage += HandleOnTakeDamage;
        }
        
        private void OnDisable()
        {
            Health.OnTakeDamage -= HandleOnTakeDamage;
        }
        
        private void HandleOnTakeDamage()
        {
            SwitchState(new PlayerImpactState(this));
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
