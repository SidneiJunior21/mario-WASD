using UnityEngine;

public class movimentaInimigo : MonoBehaviour
{
    [SerializeField] private float velocidade = 3f;
    [SerializeField] private float forcaQuiqueJogador = 8f;
    [SerializeField] private float margemVisibilidade = 0.2f;
    
    private Rigidbody2D rb;
    private bool morrendo = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D colisor;
    private int direcao = -1; // 1 esquerda, -1 direita (n sei pq mas o g1 anda invertido, tive que inverter ele manualmente)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colisor = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if (morrendo) return;
        
        bool estaNaTela = VerificarSeEstaNaTela();
        rb.linearVelocity = estaNaTela ? new Vector2(velocidade * direcao, rb.linearVelocity.y) : Vector2.zero;
    }
    bool VerificarSeEstaNaTela()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x > -margemVisibilidade && screenPoint.x < 1f + margemVisibilidade && 
               screenPoint.y > -margemVisibilidade && screenPoint.y < 1f + margemVisibilidade;
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (morrendo) return;
        if (colisao.contacts[0].normal.y < -0.5f)
        {
            Morrer();
            Rigidbody2D rbJogador = colisao.gameObject.GetComponent<Rigidbody2D>();
            rbJogador.linearVelocity = new Vector2(rbJogador.linearVelocity.x, forcaQuiqueJogador);
        }
        else if (Mathf.Abs(colisao.contacts[0].normal.x) > 0.5f)
        {
        direcao *= -1;
        }
    }
    void Morrer()
    {
        morrendo = true;
        Invoke("DesativarCompletamente", 2f);
    }
    void DesativarCompletamente()
    {
        rb.simulated = false;
        spriteRenderer.enabled = false;
        this.enabled = false;
        Destroy(gameObject, 1f);
    }
}