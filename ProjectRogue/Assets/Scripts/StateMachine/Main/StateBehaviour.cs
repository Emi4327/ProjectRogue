using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachineNamespace
{
    public abstract class StateBehaviour
    {
        public virtual void OnEnter() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnExit() { }

    }
}

