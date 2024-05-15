using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(StateMachine stateMachine)
    {
        transition = new Transition(stateMachine);
        AddTransitionCondition(StatesEnum.IdleState, new IsMoving(false));
        AddBehaviour(new PlayerMovementBehaviour(stateMachine));
        AddBehaviour(new AttackBehaviour(stateMachine));
        AddBehaviour(new PlayMoveAnimation(stateMachine));
    }
}
