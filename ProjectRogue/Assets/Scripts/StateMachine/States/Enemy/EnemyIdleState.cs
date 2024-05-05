using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    public EnemyIdleState(StateMachine machine)
    {
        this.machine = machine;
    }
}
