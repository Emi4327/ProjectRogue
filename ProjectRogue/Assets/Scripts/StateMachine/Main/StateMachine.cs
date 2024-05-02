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

        private List<Component> myComponents = new List<Component>();
        private void Start()
        {
            ChangeState(StatesEnum.IdleState);
        }

        private void Update()
        {
            Debug.Log(currentState);

            currentState.ExecuteBehavioursOnUpdate();
            currentState.CheckTransition();
        }
        private void FixedUpdate()
        {
            currentState.ExecuteBehavioursOnFixedUpdate();
        }

        public void ChangeState(StatesEnum stateEnum)
        {
            if(currentState != null)
            {
                currentState.ExecuteBehavioursOnExit();
            }
            previousState = currentState;
            currentState = states[stateEnum];
            currentState.ExecuteBehavioursOnEnter();
        }
    }
}

