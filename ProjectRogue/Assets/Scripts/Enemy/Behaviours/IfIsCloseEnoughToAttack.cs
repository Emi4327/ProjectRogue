using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IfIsCloseEnoughToAttack : StateBehaviour
{
    private StateMachine machine;
    private bool initialized;
    private EnemyAISO enemyAISO;
    private StateBehaviour stateBehaviour;
    public IfIsCloseEnoughToAttack(EnemyStateMachine machine, StateBehaviour behaviour)
    {
        stateBehaviour = behaviour;
        this.machine = machine;
        enemyAISO = machine.EnemyAISO;
    }
    public override void OnEnter()
    {
        if(AmICloseEnough())
        {
            stateBehaviour.OnEnter();
        }
    }
    public override void OnUpdate()
    {
        if(AmICloseEnough())
        {
            stateBehaviour.OnUpdate();
        }
    }
    public override void OnFixedUpdate()
    {
        if(AmICloseEnough())
        {
            stateBehaviour.OnFixedUpdate();
        }
    }
    public override void OnExit()
    {
        if(AmICloseEnough())
        {
            stateBehaviour.OnExit();
        }
    }
    private bool AmICloseEnough()
    {
        Vector3 playerPos = GameManager.Instance.Player.transform.position;
        if(Vector2.Distance(machine.transform.position, playerPos)  <= enemyAISO.AttackDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
