using UnityEngine;

public class Movimentação : MonoBehaviour
{
    private Rigidbody2D body;
    public BoxCollider2D checachao;
    public LayerMask chao;
    public float vel;
    public bool noChao;
    [Range(0f, 1f)]
    public float grav;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInp = Input.GetAxis("Horizontal");
        
        float yInp = Input.GetAxis("Vertical");
        
        Vector2 dire = new Vector2(xInp, yInp).normalized;
        body.linearVelocity = dire * vel;
    }

    void FixedUpdate()
    {
        checaNoChao();
        if (noChao && Input.GetAxis("Horizontal")==0) {
            body.linearVelocity *= grav;
        }
    }

    void checaNoChao() {
        noChao = Physics2D.OverlapAreaAll(checachao.bounds.min, checachao.bounds.max, chao).Length > 0;

    }
}
