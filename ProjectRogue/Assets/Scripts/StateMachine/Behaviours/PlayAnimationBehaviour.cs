using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationBehaviour : StateBehaviour
{
    private StateMachine machine;
    private Animator animator;
    private string animationName;
    private DoOn doOn;
    public PlayAnimationBehaviour(StateMachine machine, string animationName, DoOn on = DoOn.OnEnter)
    {
        this.machine = machine;
        animator = machine.GetComponent<Animator>();
        this.animationName = animationName;
        doOn = on;
    }

    public override void OnEnter()
    {
        if(doOn != DoOn.OnEnter) return;
        animator.Play(animationName);
    }
    public override void OnUpdate()
    {
        if(doOn != DoOn.OnUpdate) return;
        animator.Play(animationName);

    }
    public override void OnExit()
    {
        if(doOn != DoOn.OnExit) return;
    }

}
