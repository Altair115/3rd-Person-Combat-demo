namespace StateMachines.Player.States
{
    public class PlayerTargetingState : PlayerBaseState
    {
        public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _stateMachine.InputReader.TargetEvent += OnCancel;
        }

        public override void Tick(float deltaTime)
        {
            
        }

        public override void Exit()
        {
            _stateMachine.InputReader.TargetEvent -= OnCancel;
        }

        private void OnCancel()
        {
            if (_stateMachine.CurrentState != this) {return; }
            _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
        }
    }
}
