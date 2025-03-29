using UnityEngine;

public class movimentaInimigo : MonoBehaviour
{
    [SerializeField] private float velocidade = 3f;
    
    private Rigidbody2D rb;
    private int direcao = 1; // 1 esquerda, -1 direita

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.x > -0.2f && screenPoint.x < 1.2f && 
                   screenPoint.y > -0.2f && screenPoint.y < 1.2f;
    
        rb.linearVelocity = onScreen ? new Vector2(velocidade * direcao, rb.linearVelocity.y) : Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        direcao *= -1;
    }
}