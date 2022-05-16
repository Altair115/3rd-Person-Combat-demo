using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerTestState : PlayerBaseState
    {
        private float _timer = 5f;
        
        public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter");
        }

        public override void Tick(float deltaTime)
        {
            _timer -= deltaTime;
            Debug.Log(_timer);
            
            if(_timer <= 0f)
                _stateMachine.SwitchState(new PlayerTestState(_stateMachine));
        }

        public override void Exit()
        {
            Debug.Log("Exit");
        }
    }
}
