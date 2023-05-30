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
        [field: SerializeField]public Ragdoll Ragdoll { get; private set; }
        [field: SerializeField]public LedgeDetector LedgeDetector { get; private set; }
        [field: SerializeField]public float FreeLookMovementSpeed { get; private set; }
        [field: SerializeField]public float TargetingMovementSpeed { get; private set; }
        [field: SerializeField]public float RotationDampingValue { get; private set; }
        [field: SerializeField]public float DodgeDuration { get; private set; }
        [field: SerializeField]public float DodgeDistance { get; private set; }
        [field: SerializeField]public float JumpForce { get; private set; }
        [field: SerializeField]public Attack[] Attacks { get; private set; }


        public float PreviousDodgeTime { get; private set; } = Mathf.NegativeInfinity;
        public Transform MainCameraTransform { get; private set; }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            MainCameraTransform = Camera.main.transform;
            SwitchState(new PlayerFreeLookState(this));
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
            SwitchState(new PlayerImpactState(this));
        }
        
        private void HandleOnDie()
        {
            SwitchState(new PlayerDeadState(this));
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
