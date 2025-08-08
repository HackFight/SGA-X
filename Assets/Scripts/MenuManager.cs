using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    PlayerController player;
    ItemManager itemManager;
    LevelManager levelManager;

    InputAction menuAction;
    bool menuActive;
    bool escRelease;

    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        itemManager = GetComponent<ItemManager>();
        levelManager = GetComponent<LevelManager>();

        menuAction = InputSystem.actions.FindAction("Menu");
    }

    void Update()
    {
        if(menuAction.IsPressed() && escRelease)
        {
            if (menuActive)
            {
                escRelease = false;

                menuActive = false;
                pauseMenu.SetActive(false);
                player.pause = false;
            }
            else
            {
                escRelease = false;

                menuActive = true;
                pauseMenu.SetActive(true);
                player.pause = true;
            }
        }
        if (!menuAction.IsPressed() && !escRelease)
        {
            escRelease = true;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        menuActive = false;
        pauseMenu.SetActive(false);
        player.pause = false;

        player.Respawn();
        itemManager.ReloadList(levelManager.currentLevel);
    }

    public void Resume()
    {
        menuActive = false;
        pauseMenu.SetActive(false);
        player.pause = false;
    }
}
