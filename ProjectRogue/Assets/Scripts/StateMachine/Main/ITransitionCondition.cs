using System.Collections;
using System.Collections.Generic;

namespace StateMachineNamespace
{
    public interface ITransitionCondition
    {
        public bool Condition() { return false; }
    }

}
