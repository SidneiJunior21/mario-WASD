using UnityEngine;

public class Movimentacao2 : MonoBehaviour
{
    float horInp;
    float vel = 5f;
    public float pulo = 5f;
    bool taPulo = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horInp = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && !taPulo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, pulo);
            taPulo = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horInp * vel, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        taPulo = false;
    }
}
