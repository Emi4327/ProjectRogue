using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKeyPressedCondition : ITransitionCondition
{
    private KeyCode key;
    public IsKeyPressedCondition(KeyCode key)
    {
        this.key = key;
    }
    public bool Condition()
    {
        if(Input.GetKeyDown(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
