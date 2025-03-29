using UnityEngine;

public class Movimentacao2 : MonoBehaviour
{
    float horInp;
    float vel = 5f;
    public float pulo = 5f;
    bool taPulo = false;
    bool taMorto = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taMorto) return;
        horInp = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && !taPulo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, pulo);
            taPulo = true;
        }
    }

    private void FixedUpdate()
    {
        if (taMorto) return;
        rb.linearVelocity = new Vector2(horInp * vel, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (taMorto) return;
        if (collision.gameObject.CompareTag("inimigo"))
        {
            if (Mathf.Abs(collision.contacts[0].normal.x) > 0.5f)
            {
                Morrer();
            }
        }
        taPulo = false;
    }
    void Morrer()
    {
        taMorto = true;
        rb.linearVelocity = Vector2.zero;

        Destroy(gameObject, 2f); //por agr vai deletar o boneco msm fodasekkkkkk
    }
}
