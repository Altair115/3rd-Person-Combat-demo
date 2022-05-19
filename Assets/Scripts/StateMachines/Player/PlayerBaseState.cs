using System.Collections;
using System.Collections.Generic;
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

    protected void Move(Vector3 motion, float deltaTime)
    {
        _stateMachine.Controller.Move((motion + _stateMachine.ForceReciever.Movement) * deltaTime);
    }
}
