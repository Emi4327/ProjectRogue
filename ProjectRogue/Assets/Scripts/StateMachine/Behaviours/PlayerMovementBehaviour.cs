using StateMachineNamespace;
using UnityEngine;

public class PlayerMovementBehaviour : StateBehaviour
{
    private StateMachine machine;
    private InputManager inputManager;
    private Rigidbody2D rb2D;
    private Statistics stats;

    private bool canMove;
    private Vector2 moveInput;
    public PlayerMovementBehaviour(StateMachine machine)
    {
        this.machine = machine;
    }
    public override void OnEnter()
    {
        inputManager = machine.GetComponent<InputManager>();
        inputManager.MoveAction.performed += ctx => DoOnMovePressed(ctx.ReadValue<Vector2>());
        inputManager.MoveAction.canceled += ctx => DoOnPressCancel();
        rb2D = machine.GetComponent<Rigidbody2D>();
        stats = machine.GetComponent<Statistics>();
    }
    public override void OnFixedUpdate()
    {
        if (canMove)
        {
            rb2D.velocity = moveInput.normalized * stats.Speed;
        }
    }

    public override void OnExit()
    {
        inputManager.MoveAction.performed -= ctx => DoOnMovePressed(ctx.ReadValue<Vector2>());
        inputManager.MoveAction.performed -= ctx => DoOnPressCancel();
    }
    private void DoOnMovePressed(Vector2 moveInput)
    {
        canMove = true;
        this.moveInput = moveInput;
    }
    private void DoOnPressCancel()
    {
        canMove = false;
        rb2D.velocity = Vector2.zero;
    }
}
