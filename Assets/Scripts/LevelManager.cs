using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
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
    bool hasVision;

    public bool levelWon;
    public int levelAmount;

    void Start()
    {
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

    public void StartLevel()
    {
        if (currentLevel == levelAmount)
        {
            SceneManager.LoadScene(3);
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
        player.jumpSpeed = playerJumpSpeed;
    }

    public void VisionPotion()
    {
        player.speed = playerSpeed;
        hasVision = true;
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
