using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputAction moveAction;
    public InputAction MoveAction {  get { return moveAction; }  }

    private InputAction mousePosition;

    private InputAction fireAction;
    public InputAction FireAction { get { return fireAction; } }
    private void Awake()
    {
        moveAction = inputActionAsset.FindAction("Move");
        mousePosition = inputActionAsset.FindAction("MousePosition");
        fireAction = inputActionAsset.FindAction("Fire");
    }
    private void OnEnable()
    {
        inputActionAsset.Enable();
    }
    private void OnDisable()
    {
        inputActionAsset.Disable();
    }

    public InputAction GetInputAction(string name)
    {
        return inputActionAsset.FindAction(name);
    }
    public Vector2 GetMousePosition()
    {

        return mousePosition.ReadValue<Vector2>();
    }
}
