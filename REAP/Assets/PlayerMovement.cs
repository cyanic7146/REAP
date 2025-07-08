using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    private Vector2 currentMoveInput;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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
