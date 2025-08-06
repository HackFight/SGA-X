using UnityEngine;
using System.Collections.Generic;

public class Cauldron : MonoBehaviour
{
    List<GameObject> ingredients = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grabbable"))
        {
            ingredients.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grabbable"))
        {
            ingredients.Remove(collision.gameObject);
        }
    }

    void Update()
    {
        if (ingredients.Count > 3)
        {
        }
    }

    void Craft()
    {

    }
}
