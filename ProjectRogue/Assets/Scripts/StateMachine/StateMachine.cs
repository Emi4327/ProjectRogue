using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachineNamespace
{
    public class StateMachine : MonoBehaviour
    {
        private State previousState;
        private State currentState;
        protected Dictionary<StatesEnum, State > states = new Dictionary<StatesEnum, State>();
        void Start()
        {
            ChangeState(StatesEnum.IdleState);
        }

        void Update()
        {
            Debug.Log(currentState);

            currentState.OnUpdate();
            currentState.CheckTransition();
        }

        public void ChangeState(StatesEnum stateEnum)
        {
            if(currentState != null)
            {
                currentState.OnExit();
            }
            previousState = currentState;
            currentState = states[stateEnum];
            currentState.OnEnter();
        }
    }
}

