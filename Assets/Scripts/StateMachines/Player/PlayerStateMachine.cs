using StateMachines.Player.States;

namespace StateMachines.Player
{
    public class PlayerStateMachine : StateMachine
    {
        // Start is called before the first frame update
        void Start()
        {
            SwitchState(new PlayerTestState(this));
        }
    }
}
