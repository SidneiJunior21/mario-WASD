using UnityEngine;

public class Movimentação : MonoBehaviour
{
    private Rigidbody2D body;
    public float vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInp = Input.GetAxis("Horizontal");
        float yInp = Input.GetAxis("Vertical");
        
        Vector2 dire = new Vector2(xInp, yInp).normalized;
        body.linearVelocity = dire * vel;
    }



}
