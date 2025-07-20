using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    private Vector2 currentMoveInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovementPlayer();
    }
    public void OnMovement(InputValue value)
    {
        currentMoveInput = value.Get<Vector2>();
    }
    void MovementPlayer()
    {
        Vector2 move = new(currentMoveInput.x, currentMoveInput.y);
        rb.linearVelocityY = move.y * verticalSpeed;
        rb.linearVelocityX = move.x * horizontalSpeed;
    }
}