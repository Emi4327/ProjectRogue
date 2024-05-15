using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] private EnemyAISO enemyAISO;
    public EnemyAISO EnemyAISO {  get { return enemyAISO; } }
    private void Awake()
    {
        InitStates();
    }
    private void InitStates()
    {
        states.Add(StatesEnum.EnemyIdleState, new EnemyIdleState(this));
        states.Add(StatesEnum.EnemyMoveToPlayerState, new EnemyMoveToPlayerState(this));
        ChangeState(StatesEnum.EnemyIdleState);
    }
}
