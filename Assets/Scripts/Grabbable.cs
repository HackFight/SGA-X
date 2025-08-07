using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour
{
    public bool untouched = true;
    public float grabSpeed;

    Rigidbody2D rb;
    Vector2 lastPos;

    Vector2 startPos;

    void Start()
    {
        untouched = true;
        rb = GetComponent<Rigidbody2D>();

        startPos = transform.position;
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        rb.gravityScale = 1.0f;

        rb.linearVelocity = ((Vector2)transform.position - lastPos) * (1 / Time.fixedDeltaTime);
        lastPos = transform.position;
    }

    public void Init()
    {
        transform.position = startPos;
        lastPos = transform.position;
    }
}
