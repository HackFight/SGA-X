using Unity.Cinemachine;
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

    //Cam
    CinemachineCamera cineCam;
    [SerializeField] float beginCameraSize;
    [SerializeField] float finalCameraSize;

    //Player stats
    float playerSpeed;
     float playerJumpSpeed;
    [SerializeField] float beginSpeed;

    //Potion stuff
    bool hasJump;
    bool hasVision;

    public bool levelWon;
    public int levelAmount;

    void Start()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
        itemManager = GetComponent<ItemManager>();
        wallManager = GetComponent<WallManager>();
        animationHandler = GetComponent<ScriptedAnimations>();

        cineCam = GameObject.FindWithTag("CinemachineCamera").GetComponent<CinemachineCamera>();

        lastReloadTime = Time.time;

        playerSpeed = player.speed;
        playerJumpSpeed = player.jumpSpeed;
        player.speed = beginSpeed;
        player.jumpSpeed = 0;
    }

    void Update()
    {
        
        if (menuAction.IsPressed() && Time.time > lastReloadTime + reloadCooldown)
        {
            //Open menu
        }
    }

    public void StartLevel()
    {
        if (currentLevel == levelAmount)
        {
            Debug.Log("YEEEEEEEEEEPEEEEEEEEE");
        }
        else
        {
            itemManager.ReloadList(currentLevel);
            wallManager.DisableList(currentLevel);
            player.Respawn();
            animationHandler.FreeCamera();

            if(currentLevel == 1)
            {
                JumpPotion();
            }
            else if (currentLevel == 2)
            {
                VisionPotion();
            }
        }

        cineCam.Lens.OrthographicSize = hasVision ? finalCameraSize : beginCameraSize;
        animationHandler.canvas.SetActive(true);
    }

    public void EndLevel(bool win)
    {
        levelWon = win;
        player.LookRight();
        animationHandler.PlayCutscene(currentLevel);
        currentLevel++;
    }  

    public void JumpPotion()
    {
        hasJump = true;
        player.jumpSpeed = playerJumpSpeed;
    }

    public void VisionPotion()
    {
        player.speed = playerSpeed;
        hasVision = true;
    }
}
