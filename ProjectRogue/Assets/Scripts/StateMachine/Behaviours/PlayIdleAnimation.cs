using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIdleAnimation : StateBehaviour
{
    private Animator animator;
    private InputManager inputManager;
    private StateHelperSO stateHelper;

    public PlayIdleAnimation(StateMachine machine)
    {
        animator = machine.GetComponent<Animator>();
        inputManager = machine.GetComponent<InputManager>();
        stateHelper = Resources.Load<StateHelperSO>("StateHelpers/AnimationsHelper");
    }

    public override void OnUpdate()
    {
        Debug.Log(stateHelper);
        if(IsLookingRight())
        {
            animator.Play(stateHelper.idleRightAnimation.name);
        }
        else
        {
            animator.Play(stateHelper.idleLeftAnimation.name);
        }
    }
    private bool IsLookingRight()
    {
        if(inputManager.GetMousePosition().x >= Screen.width / 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
