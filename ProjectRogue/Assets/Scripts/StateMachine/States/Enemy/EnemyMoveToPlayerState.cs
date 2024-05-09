using Pathfinding;
using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToPlayerState : State
{
    public EnemyMoveToPlayerState(EnemyStateMachine machine)
    {
        this.machine = machine;
       // AddTransitionCondition(StatesEnum.MoveState, new IsKeyPressedCondition("Move"));
        AddBehaviour(new EnemyMoveBehaviour(machine));
        AddBehaviour(new IfIsCloseEnoughToAttack(machine, new EnemyAttack(machine)));
        
    }
  
}
