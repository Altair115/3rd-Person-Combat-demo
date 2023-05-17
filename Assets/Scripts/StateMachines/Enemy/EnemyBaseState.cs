using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachines;
//using StateMachines.Enemy;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine _stateMachine;
    
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
