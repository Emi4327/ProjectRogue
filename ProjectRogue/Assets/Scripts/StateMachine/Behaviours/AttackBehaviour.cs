using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateBehaviour
{
    private StateMachine machine;
    private InputManager inputManager;
    private WeaponsManager weaponsManager;
    public AttackBehaviour(StateMachine machine)
    {
        this.machine = machine;
        inputManager = machine.GetComponent<InputManager>();
        weaponsManager = machine.GetComponentInChildren<WeaponsManager>();
    }

    public override void OnEnter()
    {
        inputManager.FireAction.performed += ctx => Attack();
    }
    public override void OnExit()
    {
        inputManager.FireAction.performed -= ctx => Attack();
    }
    private void Attack()
    {
        weaponsManager.Attack();
    }
}
