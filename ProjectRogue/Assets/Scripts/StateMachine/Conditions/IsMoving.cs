using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsMoving : ITransitionCondition
{
    private StateMachine machine;
    private Rigidbody2D rb2D;
    private bool isTrue;
    private bool isInitialized;
    public IsMoving(bool isTrue = true)
    {
        this.isTrue = isTrue;
    }

    public bool Condition(StateMachine machine)
    {
        if(!isInitialized)
        {
            Initialize(machine);
        }

        if(Mathf.Approximately(rb2D.velocity.x, 0) && Mathf.Approximately(rb2D.velocity.y, 0))
        {
            if(isTrue)
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
            if(isTrue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    private void Initialize(StateMachine machine)
    {
        isInitialized = true;
        rb2D = machine.GetComponent<Rigidbody2D>();
    }

}
