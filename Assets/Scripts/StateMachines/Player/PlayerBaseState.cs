using StateMachines;
using StateMachines.Player;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine _stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        _stateMachine.Controller.Move((motion + _stateMachine.ForceReciever.Movement) * deltaTime);
    }
    
    protected void FaceTarget()
    {
        if (_stateMachine.Targeter.CurrentTarget == null) { return; }

        Vector3 lookPosition = _stateMachine.Targeter.CurrentTarget.transform.position - _stateMachine.transform.position;
        lookPosition.y = 0f;

        _stateMachine.transform.rotation = Quaternion.LookRotation(lookPosition);
    }
}
