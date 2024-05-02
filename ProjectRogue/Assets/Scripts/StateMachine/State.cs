using System.Collections.Generic;
using Unity.VisualScripting;

namespace StateMachineNamespace
{
    public abstract class State
    {
        protected Transition transition;
        protected StateMachine machine;
        public virtual void OnEnter() { }
        public virtual void OnUpdate() { }
        public virtual void OnExit() { }

        public void CheckTransition()
        {
            transition.CheckConditions();
        }

        protected void AddTransitionCondition(StatesEnum stateEnum, ITransitionCondition condition)
        {
            transition.AddCondition(condition, stateEnum);
        }
    }
}
