using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float grabSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.Sleep();
    }
}
