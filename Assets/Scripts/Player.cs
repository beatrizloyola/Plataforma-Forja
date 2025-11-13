using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 10f;
    public Transform chaoTeste;
    public float chaoTesteRaio = 0.2f;
    public LayerMask chaoCamada;
    public bool noChao;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float entrada = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(entrada * velocidade, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }

    private void FixedUpdate() {
        noChao = Physics2D.OverlapCircle(chaoTeste.position, chaoTesteRaio, chaoCamada);
    }
}
