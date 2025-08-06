using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    InputAction menuAction;
    ItemManager itemManager;

    public PlayerController player;
    public int currentLevel = 0;

    void Start()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
        itemManager = GetComponent<ItemManager>();
    }

    void Update()
    {
        if (menuAction.IsPressed())
        {
            itemManager.ReloadList(currentLevel);
            player.Respawn();
        }
    }
}
