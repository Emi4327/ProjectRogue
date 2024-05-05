using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    private void Awake()
    {
        InitStates();
    }
    private void InitStates()
    {
        states.Add(StatesEnum.IdleState, new EnemyIdleState(this));
        states.Add(StatesEnum.MoveState, new EnemyMoveToPlayerState(this));
    }
}
