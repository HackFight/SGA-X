using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bind : MonoBehaviour
{
    public Transform bind;

    void FixedUpdate()
    {
        transform.position = bind.position;
    }
}
