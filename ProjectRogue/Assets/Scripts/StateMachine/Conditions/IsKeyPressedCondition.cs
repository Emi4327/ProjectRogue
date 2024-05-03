using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace StateMachineNamespace
{
    public class IsKeyPressedCondition : ITransitionCondition
    {
        private StateMachine machine;
        private string inputActionName;
        private InputAction inputAction;
        private bool initialized;
        public IsKeyPressedCondition(string inputActionName)
        {
            this.inputActionName = inputActionName;
        }
        public bool Condition(StateMachine machine)
        {
            if(!initialized)
            {
                Initialize(machine);
            }
            if(inputAction.IsPressed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Initialize(StateMachine machine)
        {
            inputAction = machine.GetComponent<InputManager>().GetInputAction(inputActionName);

            initialized = true;
        }

    }
}

