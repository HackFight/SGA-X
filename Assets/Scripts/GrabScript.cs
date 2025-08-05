using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public float grabStrength;
    List<GameObject> grabbeds = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("AAAAAAAAAA");
        //Add grabable colliders to list
        if(collision.CompareTag("Grabbable"))
        {
            grabbeds.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        Debug.Log("BBBBBBBBB");
        //Remove grabable collider from list
        if (collision.CompareTag("Grabbable"))
        {
            collision.GetComponent<Grabbable>().grabbed = false;
            grabbeds.Remove(collision.GetComponent<Rigidbody2D>());
        }
        */
    }

    public void Activate()
    {
        //Magnet mode on
        foreach (var grabbable in grabbeds)
        {
            Grabbable script = grabbable.GetComponent<Grabbable>();
            Rigidbody2D rb = grabbable.GetComponent<Rigidbody2D>();
            script.grabbed = true;
            rb.gravityScale = 0.0f;
            rb.AddForce((transform.position - grabbable.transform.position).normalized * grabStrength);
        }
    }
}
