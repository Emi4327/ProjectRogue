using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(StateMachine machine)
    {
        transition = new Transition(machine);
        AddTransitionCondition(StatesEnum.IdleState, new IsKeyPressedCondition(KeyCode.T));
        AddBehaviour(new PlayerMovementBehaviour(machine));
    }
}
