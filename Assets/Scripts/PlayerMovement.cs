using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Detection")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public Transform groundTest;

    // Variáveis privadas para componentes
    private Rigidbody2D rb;
    private Animator anim; // Referência ao Animator
    private SpriteRenderer spriteRenderer; // Para virar o sprite
    private bool isGrounded;

    private string[] levels = { "Fase1", "Fase2" };
    private int levelsCompleted = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Pega o Animator
        spriteRenderer = GetComponent<SpriteRenderer>(); // Pega o SpriteRenderer

        if (rb != null)
        {
            rb.gravityScale = 3f;
        }
    }

    void Update()
    {
        // 1. Verifica se está no chão
        isGrounded = Physics2D.OverlapCircle(groundTest.position, 0.15f, groundLayer);

        // 2. Input de movimento horizontal
        float horizontal = 0.0f;

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            horizontal = 1.0f;
        }

        // 3. Move horizontalmente
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        // 4. Virar o Sprite (Flip)
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false; // Olha para a direita
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true; // Olha para a esquerda
        }

        // 5. Input de pulo
        if ((Keyboard.current.upArrowKey.wasPressedThisFrame ||
             Keyboard.current.wKey.wasPressedThisFrame ||
             Keyboard.current.spaceKey.wasPressedThisFrame) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // 6. Atualiza o Animator
        UpdateAnimations(horizontal);
    }

    void UpdateAnimations(float horizontalInput)
    {
        // Define se está correndo (valor absoluto para ser sempre positivo)
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Passa se está no chão ou não
        anim.SetBool("IsGrounded", isGrounded);

        // Passa a velocidade vertical (para saber se está subindo ou caindo)
        anim.SetFloat("vSpeed", rb.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            // Verifica se existe uma próxima fase antes de carregar para evitar erro
            if (levelsCompleted + 1 < levels.Length)
            {
                levelsCompleted += 1;
                SceneManager.LoadScene(levels[levelsCompleted]);
            }
            else
            {
                Debug.Log("Última fase completada!");
            }
        }
    }
}