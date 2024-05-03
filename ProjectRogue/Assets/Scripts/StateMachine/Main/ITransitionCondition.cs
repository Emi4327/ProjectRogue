using System.Collections;
using System.Collections.Generic;

namespace StateMachineNamespace
{
    public interface ITransitionCondition
    {
        public void Initialize(StateMachine machine) { }
        public bool Condition(StateMachine machine) { return false; }
    }

}
