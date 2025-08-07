using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    InputAction menuAction;
    ItemManager itemManager;
    WallManager wallManager;

    [SerializeField] PlayerController player;
    public int currentLevel = 0;
    [SerializeField] float reloadCooldown;
    float lastReloadTime;

    void Start()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
        itemManager = GetComponent<ItemManager>();
        wallManager = GetComponent<WallManager>();

        lastReloadTime = Time.time;
    }

    void Update()
    {
        if (menuAction.IsPressed() && Time.time > lastReloadTime + reloadCooldown)
        {
            lastReloadTime = Time.time;
            player.Respawn();
            itemManager.ReloadList(currentLevel);
            wallManager.DisableList(currentLevel);
        }
    }
}
