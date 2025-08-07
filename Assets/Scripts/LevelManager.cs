using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    InputAction menuAction;
    ItemManager itemManager;
    WallManager wallManager;
    ScriptedAnimations animationHandler;

    [SerializeField] PlayerController player;
    public int currentLevel = 0;
    [SerializeField] float reloadCooldown;
    float lastReloadTime;

    public bool levelWon;

    void Start()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
        itemManager = GetComponent<ItemManager>();
        wallManager = GetComponent<WallManager>();
        animationHandler = GetComponent<ScriptedAnimations>();

        lastReloadTime = Time.time;
    }

    void Update()
    {
        
        if (menuAction.IsPressed() && Time.time > lastReloadTime + reloadCooldown)
        {
            /*
            lastReloadTime = Time.time;
            player.Respawn();
            itemManager.ReloadList(currentLevel);
            wallManager.DisableList(currentLevel);
            */
            animationHandler.PlayCutscene(0);
        }
    }

    public void StartLevel()
    {
        itemManager.ReloadList(currentLevel);
        wallManager.DisableList(currentLevel);
        player.cutscene = false;
    }

    public void EndLevel(bool win)
    {
        levelWon = win;
        animationHandler.PlayCutscene(currentLevel);
        currentLevel++;
    }  
}
