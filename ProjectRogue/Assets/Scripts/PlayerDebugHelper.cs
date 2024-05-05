using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebugHelper : MonoBehaviour
{
    private StateMachine machine;

    public string currentState;
    void Start()
    {
        machine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = machine.GetCurrentStateName();
    }
}
