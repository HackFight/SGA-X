using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    List<GameObject> grabbeds = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add grabable colliders to list
        if(collision.CompareTag("Grabbable"))
        {
            grabbeds.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Remove grabable collider from list
        if (collision.CompareTag("Grabbable"))
        {
            if (!collision.GetComponent<Grabbable>().untouched)
            {
                collision.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            }
            grabbeds.Remove(collision.gameObject);
        }
    }

    public void Activate()
    {
        //Magnet mode on
        foreach (GameObject grabbable in grabbeds)
        {
            Grabbable script = grabbable.GetComponent<Grabbable>();
            Rigidbody2D rb = grabbable.GetComponent<Rigidbody2D>();
            script.untouched = false;
            rb.gravityScale = 0.0f;
            Vector2 dif = transform.position - grabbable.transform.position;
            rb.MovePosition((Vector2)rb.transform.position + dif * Time.fixedDeltaTime * script.grabSpeed);
        }
    }
}
