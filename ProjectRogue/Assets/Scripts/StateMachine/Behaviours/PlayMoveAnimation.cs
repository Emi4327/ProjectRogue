using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMoveAnimation : StateBehaviour
{
    private Animator animator;
    private InputManager inputManager;
    private StateHelperSO stateHelper;

    public PlayMoveAnimation(StateMachine machine)
    {
        animator = machine.GetComponent<Animator>();
        inputManager = machine.GetComponent<InputManager>();
        stateHelper = Resources.Load<StateHelperSO>("StateHelpers/AnimationsHelper");
    }

    public override void OnUpdate()
    {
        if(IsLookingRight())
        {
            animator.Play(stateHelper.moveRightAnimation.name);
        }
        else
        {
            animator.Play(stateHelper.moveLeftAnimation.name);
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
