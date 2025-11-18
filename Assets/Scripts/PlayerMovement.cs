using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public Transform groundTest;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 3f;
        }
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(groundTest.position, Vector2.down, groundCheckDistance, groundLayer);

        float horizontal = 0.0f;
        
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            horizontal = 1.0f;
        }

        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        if ((Keyboard.current.upArrowKey.wasPressedThisFrame || 
             Keyboard.current.wKey.wasPressedThisFrame || 
             Keyboard.current.spaceKey.wasPressedThisFrame) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }


}