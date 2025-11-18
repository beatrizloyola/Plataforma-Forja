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

    private string[] levels = {"Fase1", "Fase2", "Fase3"};

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            // Pega o índice da cena atual
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            // Carrega a próxima cena
            int nextSceneIndex = currentSceneIndex + 1;
            
            // Verifica se não passou do limite
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}