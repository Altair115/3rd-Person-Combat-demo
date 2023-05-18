namespace StateMachines.Enemy
{
    public abstract class EnemyBaseState : State
    {
        protected EnemyStateMachine _stateMachine;

        public EnemyBaseState(EnemyStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}
