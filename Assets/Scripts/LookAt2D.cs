using UnityEngine;
using UnityEngine.EventSystems;

public class LookAt2D : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
