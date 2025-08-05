using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool grabbed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.Sleep();
    }

    void Update()
    {
        if (!grabbed)
        {
            rb.gravityScale = 1.0f;
        }
    }
}
