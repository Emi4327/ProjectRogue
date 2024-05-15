using StateMachineNamespace;
using UnityEngine;

public class PlayerMovementBehaviour : StateBehaviour
{
    private StateMachine machine;
    private InputManager inputManager;
    private Rigidbody2D rb2D;
    private Statistics stats;
    private PlayerHelper playerHelper;
    private Vector2 moveInput;
    public PlayerMovementBehaviour(StateMachine machine)
    {
        this.machine = machine;
        playerHelper = machine.GetComponent<PlayerHelper>();
        rb2D = machine.GetComponent<Rigidbody2D>();
        stats = machine.GetComponent<Statistics>();
        inputManager = machine.GetComponent<InputManager>();
        inputManager.MoveAction.performed += ctx => DoOnMovePressed(ctx.ReadValue<Vector2>());
        inputManager.MoveAction.canceled += ctx => DoOnPressCancel();
    }
    public override void OnEnter()
    {
        inputManager.MoveAction.performed += ctx => DoOnMovePressed(ctx.ReadValue<Vector2>());
        inputManager.MoveAction.canceled += ctx => DoOnPressCancel();
    }
    public override void OnFixedUpdate()
    {
        if (playerHelper.IsMoving)
        {
            Vector2 velocity = moveInput.normalized * stats.Speed;
            rb2D.velocity = velocity;
        }
    }

    public override void OnExit()
    {
        inputManager.MoveAction.performed -= ctx => DoOnMovePressed(ctx.ReadValue<Vector2>());
        inputManager.MoveAction.performed -= ctx => DoOnPressCancel();
    }
    private void DoOnMovePressed(Vector2 moveInput)
    {
        playerHelper.IsMoving = true;
        this.moveInput = moveInput;
    }
    private void DoOnPressCancel()
    {
        rb2D.velocity = Vector2.zero;
        playerHelper.IsMoving = false;
    }
}
