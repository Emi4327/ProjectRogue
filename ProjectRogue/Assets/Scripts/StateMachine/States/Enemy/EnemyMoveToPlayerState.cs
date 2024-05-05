using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToPlayerState : State
{
    public EnemyMoveToPlayerState(StateMachine machine)
    {
        this.machine = machine;
    }
}
