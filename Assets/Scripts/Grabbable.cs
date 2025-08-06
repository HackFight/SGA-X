using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool untouched = true;
    public float grabSpeed;

    Rigidbody2D rb;
    Vector2 lastPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(untouched) rb.Sleep();

        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        rb.gravityScale = 1.0f;

        rb.linearVelocity = ((Vector2)transform.position - lastPos) * (1 / Time.fixedDeltaTime);
        lastPos = transform.position;
    }
}
