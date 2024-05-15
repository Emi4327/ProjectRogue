using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoIfIsLookingRight : StateBehaviour
{
    private InputManager inputManager;
    private StateBehaviour behaviour;
    private bool shouldBeTrue;
    public DoIfIsLookingRight(StateMachine machine, StateBehaviour behaviour, bool shouldBeTrue)
    {
        inputManager = machine.GetComponent<InputManager>();
        this.behaviour = behaviour;
        this.shouldBeTrue = shouldBeTrue;
    }

    public override void OnEnter()
    {
        if(Check())
        {
            behaviour.OnEnter();
        }
    }
    public override void OnUpdate()
    {
        if(Check())
        {
            behaviour.OnUpdate();
        }
    }
    public override void OnFixedUpdate()
    {
        if(Check())
        {
            behaviour.OnFixedUpdate();
        }
    }
    public override void OnExit()
    {
        if(Check())
        {
            behaviour.OnExit();
        }
    }
    public bool Check()
    {
        if(inputManager.GetMousePosition().x >= Screen.width / 2)
        {
            if(shouldBeTrue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(shouldBeTrue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
