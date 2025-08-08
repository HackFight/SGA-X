using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    private InputAction pauseAction;

    public GameObject PauseScreen;
    bool paused = false;

    void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Menu");
    }

    void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            paused = togglePause();
        }

        if (paused)
        {
            PauseScreen.SetActive(true);
        }
        else
        {
            PauseScreen.SetActive(false);
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }

    public void ContinueButton()
    {
        paused = togglePause();
    }

    public void MenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void RestartButton()
    {
        
    }
}
