using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public EventSystem eventSystem;
    public GameObject backButton;
    public GameObject playButton;



    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        Credits.text.credit = true;
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(backButton);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(playButton);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }

}