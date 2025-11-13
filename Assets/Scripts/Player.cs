using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float entrada = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(entrada * velocidade, rb.linearVelocity.y);
    }
}
