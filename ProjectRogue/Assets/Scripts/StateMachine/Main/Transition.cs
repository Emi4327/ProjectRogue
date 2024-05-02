using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachineNamespace
{
    public class Transition
    {
        private StateMachine machine;
        private Dictionary<StatesEnum, List<ITransitionCondition>> transitionConditions = new Dictionary<StatesEnum, List<ITransitionCondition>>();
        private List<StatesEnum> stateKeys = new List<StatesEnum>();

        public Transition(StateMachine machine)
        {
            this.machine = machine;
        }
        public void AddCondition(ITransitionCondition condition, StatesEnum toState)
        {
            if(transitionConditions.ContainsKey(toState))
            {
                transitionConditions[toState].Add(condition);
            }
            else
            {
                transitionConditions.Add(toState, new List<ITransitionCondition>());
                transitionConditions[toState].Add(condition);
                stateKeys.Add(toState);
            }
        }

        public void CheckConditions()
        {
            foreach(var state in stateKeys)
            {
                int amountOfAllConditions = transitionConditions[state].Count;
                int counter = 0;
                foreach(var condition in transitionConditions[state])
                {
                    if(condition.Condition())
                    {
                        counter++;
                    }
                }
                if(counter == amountOfAllConditions)
                {
                    Debug.Log("Counter: " + counter + "   transitionConditions count: " + transitionConditions[state].Count);
                    machine.ChangeState(state);
                    return;
                }
            }
        }
    }
}

