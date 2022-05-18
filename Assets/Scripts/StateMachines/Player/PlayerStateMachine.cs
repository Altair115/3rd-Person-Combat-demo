using StateMachines.Player.States;
using UnityEngine;

namespace StateMachines.Player
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField]public InputReader InputReader { get; private set; }
        [field: SerializeField]public CharacterController Controller { get; private set; }
        [field: SerializeField]public Animator Animator { get; private set; }
        [field: SerializeField]public float OutOfCombatSpeed { get; private set; }
        public Transform MainCameraTransform { get; private set; }

        private void Start()
        {
            MainCameraTransform = Camera.main.transform;
            SwitchState(new PlayerTestState(this));
        }
    }
}
