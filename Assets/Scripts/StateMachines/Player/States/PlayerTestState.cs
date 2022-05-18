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
            _stateMachine.transform.Translate(movement * deltaTime);
        }

        public override void Exit()
        {
        }
    }
}
