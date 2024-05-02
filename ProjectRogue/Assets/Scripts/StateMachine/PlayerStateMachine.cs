using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private void Awake()
    {
        InitStates();
    }
    private void InitStates()
    {
        states.Add(StatesEnum.IdleState, new IdleState(this));
        states.Add(StatesEnum.MoveState, new MoveState(this));
    }
}
