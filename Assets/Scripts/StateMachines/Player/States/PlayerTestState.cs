using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerTestState : PlayerBaseState
    {
        public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            Vector3 movement = new Vector3();
            movement.x = _stateMachine.InputReader.MovementValue.x;
            movement.y = 0;
            movement.z = _stateMachine.InputReader.MovementValue.y;
            _stateMachine.Controller.Move(movement * (_stateMachine.OutOfCombatSpeed * deltaTime));

            if (_stateMachine.InputReader.MovementValue == Vector2.zero)
            {
                _stateMachine.Animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);
                return;
            }
            _stateMachine.Animator.SetFloat("FreeLookSpeed", 1, 0.1f, deltaTime);
            _stateMachine.transform.rotation = Quaternion.LookRotation(movement);
        }

        public override void Exit()
        {
        }
    }
}
