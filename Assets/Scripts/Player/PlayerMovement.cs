using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boundaryLimit = 23f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerInputActions inputActions;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMoveCanceled;
    }

    void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMoveCanceled;
        inputActions.Player.Disable();
        inputActions.Dispose();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        if (movement.x > 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (movement.x < 0)
            GetComponent<SpriteRenderer>().flipX = false;
    }

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        movement = Vector2.zero;
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -boundaryLimit, boundaryLimit);
        newPosition.y = Mathf.Clamp(newPosition.y, -boundaryLimit, boundaryLimit);

        rb.MovePosition(newPosition);
    }
}