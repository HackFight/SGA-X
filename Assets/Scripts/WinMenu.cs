using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject Debug;
    public GameObject Win;
    public EventSystem eventSystem;
    public GameObject menuButton;
    public GameObject backButton;

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Drink()
    {
        Debug.SetActive(true);
        Win.SetActive(false);
        eventSystem.SetSelectedGameObject(backButton);
    }

    public void Back()
    {
        Debug.SetActive(false);
        Win.SetActive(true);
        eventSystem.SetSelectedGameObject(menuButton);
    }
}
