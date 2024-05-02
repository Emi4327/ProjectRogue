using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputAction moveAction;
    public InputAction MoveAction {  get { return moveAction; }  }
    private void Awake()
    {
        moveAction = inputActionAsset.FindAction("Move");
    }
    private void OnEnable()
    {
        inputActionAsset.Enable();
    }
    private void OnDisable()
    {
        inputActionAsset.Disable();
    }
}
