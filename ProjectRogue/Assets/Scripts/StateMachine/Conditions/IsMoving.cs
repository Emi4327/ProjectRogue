using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsMoving : ITransitionCondition
{
    private StateMachine machine;
    private Rigidbody2D rb2D;
    private PlayerHelper playerHelper;
    private bool shouldBeTrue;
    private bool isInitialized;
    
    public IsMoving(bool shouldBeTrue = true)
    {
        this.shouldBeTrue = shouldBeTrue;
    }

    public bool Condition(StateMachine machine)
    {
        if(!isInitialized)
        {
            Initialize(machine);
        }

        if(shouldBeTrue)
        {
            return playerHelper.IsMoving;
        }
        else
        {
            return !playerHelper.IsMoving;
        }
    }
    private void Initialize(StateMachine machine)
    {
        isInitialized = true;
        rb2D = machine.GetComponent<Rigidbody2D>();
        playerHelper = machine.GetComponent<PlayerHelper>();
    }

}
