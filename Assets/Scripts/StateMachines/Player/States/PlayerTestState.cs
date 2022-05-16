using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerTestState : PlayerBaseState
    {
        private float _timer;
        
        public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.InputReader.OnJumpEvent += OnJump;
            Debug.Log("Enter");
        }

        public override void Tick(float deltaTime)
        {
            _timer += deltaTime;
            
            Debug.Log(_timer);
        }

        public override void Exit()
        {
            _stateMachine.InputReader.OnJumpEvent -= OnJump;
            Debug.Log("Exit");
        }


        private void OnJump()
        {
            _stateMachine.SwitchState(new PlayerTestState(_stateMachine));
        }
    }
}
