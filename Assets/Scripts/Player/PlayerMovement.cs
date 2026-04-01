using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
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
    }

    void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

        // Flip sprite based on horizontal movement
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
        Debug.Log("FixedUpdate - movement: " + movement + " | rb position: " + rb.position);
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}