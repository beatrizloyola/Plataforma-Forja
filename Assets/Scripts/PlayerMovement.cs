using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public Transform groundTest;

    private Rigidbody2D rb;
    private bool isGrounded;

    private string[] levels = {"Fase1", "Fase2"};
    private int levelsCompleted = 0;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            levelsCompleted += 1;
            SceneManager.LoadScene(levels[levelsCompleted]);
        }
    }
}