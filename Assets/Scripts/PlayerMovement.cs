using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public Transform groundTest;

    private bool isGrounded;

    void Update()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;

        // Faz a checagem do chão (raio para baixo)
        isGrounded = Physics2D.Raycast(groundTest.position, Vector2.down, groundCheckDistance, groundLayer);

        // Verifica se as teclas de movimento estão pressionadas
        if ((Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed || Keyboard.current.spaceKey.isPressed) && isGrounded)
        {
            vertical = 1.2f;
        }
        else if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            horizontal = 1.0f;
        }

        Debug.Log(horizontal);

        // Move o jogador
        Vector2 position = transform.position;
        position.x += 0.1f * horizontal;
        position.y += 0.1f * vertical;
        transform.position = position;
    }
}
