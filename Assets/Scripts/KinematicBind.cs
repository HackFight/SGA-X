using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KinematicBind : MonoBehaviour
{
    public Transform bind;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(bind.position);
    }
}
