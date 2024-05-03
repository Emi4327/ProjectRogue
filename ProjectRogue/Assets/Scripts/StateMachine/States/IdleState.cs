using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineNamespace;
using UnityEngine.InputSystem;
public class IdleState : State
{
    public IdleState(StateMachine stateMachine)
    {
        transition = new Transition(stateMachine);

        AddTransitionCondition(StatesEnum.MoveState, new IsKeyPressedCondition("Move"));
    }

}


