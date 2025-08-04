using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    List<Rigidbody2D> grabbeds = new List<Rigidbody2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add grabable colliders to list
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Remove grabable collider from list
    }

    public void Activate()
    {
        //Magnet mode on
    }
}
