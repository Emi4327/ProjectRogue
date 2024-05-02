using System.Collections.Generic;
using Unity.VisualScripting;

namespace StateMachineNamespace
{
    public class State
    {
        protected Transition transition;
        protected StateMachine machine;
        private List<StateBehaviour> behaviours = new List<StateBehaviour>();
        public void CheckTransition()
        {
            transition.CheckConditions();
        }

        protected void AddTransitionCondition(StatesEnum stateEnum, ITransitionCondition condition)
        {
            transition.AddCondition(condition, stateEnum);
        }

        protected void AddBehaviour(StateBehaviour behaviour)
        {
            behaviours.Add(behaviour);
        }

        public void ExecuteBehavioursOnEnter()
        {
            foreach(var behaviour in behaviours)
            {
                behaviour.OnEnter();
            }
        }
        public void ExecuteBehavioursOnUpdate()
        {
            foreach(var behaviour in behaviours)
            {
                behaviour.OnUpdate();
            }
        }
        public void ExecuteBehavioursOnFixedUpdate()
        {
            foreach(var behaviour in behaviours)
            {
                behaviour.OnFixedUpdate();
            }
        }
        public void ExecuteBehavioursOnExit()
        {
            foreach(var behaviour in behaviours)
            {
                behaviour.OnExit();
            }
        }
    }
}
