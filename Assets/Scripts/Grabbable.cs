using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool untouched = true;
    public float grabSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(untouched) rb.Sleep();
    }
}
