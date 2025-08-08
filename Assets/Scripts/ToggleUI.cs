using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject UI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }
}
