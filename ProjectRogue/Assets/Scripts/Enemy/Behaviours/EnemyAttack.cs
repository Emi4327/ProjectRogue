using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineNamespace;
public class EnemyAttack : StateBehaviour
{
    private EnemyStateMachine machine;
    private Transform target;
    private float timer;
    private EnemyAISO enemyAISO;
    private WeaponsManager weaponsManager;
    public EnemyAttack(EnemyStateMachine machine)
    {
        this.machine = machine;
        target = machine.GetComponent<EnemyAIHelper>().Target;
        weaponsManager = machine.GetComponentInChildren<WeaponsManager>();
        enemyAISO = machine.EnemyAISO;
    }
    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= 1 / enemyAISO.AttackSpeed)
        {
            weaponsManager.Attack();
            timer = 0;
        }
    }
}
