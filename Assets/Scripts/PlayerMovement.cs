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
            rb.gravityScale = 3f; // Ajuste conforme necessário
        }
    }

    void Update()
    {
        // Verifica se está no chão
        isGrounded = Physics2D.Raycast(groundTest.position, Vector2.down, groundCheckDistance, groundLayer);

        // Input de movimento horizontal
        float horizontal = 0.0f;
        
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            horizontal = 1.0f;
        }

        // Move horizontalmente usando velocidade
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        // Input de pulo
        if ((Keyboard.current.upArrowKey.wasPressedThisFrame || 
             Keyboard.current.wKey.wasPressedThisFrame || 
             Keyboard.current.spaceKey.wasPressedThisFrame) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}