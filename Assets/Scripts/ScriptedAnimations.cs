using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[RequireComponent(typeof(PlayableDirector))]
[RequireComponent(typeof(LevelManager))]
public class ScriptedAnimations : MonoBehaviour
{
    //Cam
    CinemachineCamera cineCam;
    public Transform custsceneCameraTarget;
    [SerializeField] float cutsceneLensSize;

    //Player
    GameObject player;
    PlayerController playerController;

    //Timeline
    PlayableDirector playableDirector;
    [SerializeField] TimelineAsset cutscene;
    [SerializeField] List<TimelineAsset> starts = new List<TimelineAsset>();
    [SerializeField] TimelineAsset deathCutscene;

    //Cauldron
    public SpriteRenderer potionSpriteRenderer;
    public List<Sprite> potionSprites = new List<Sprite>();

    //Other
    LevelManager levelManager;
    public GameObject canvas;

    private void Start()
    {
        cineCam = GameObject.FindWithTag("CinemachineCamera").GetComponent<CinemachineCamera>();

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playableDirector = GetComponent<PlayableDirector>();
        levelManager = GetComponent<LevelManager>();
    }

    public void PlayCutscene(int level)
    {
        //Camera
        cineCam.Target.TrackingTarget = custsceneCameraTarget;
        cineCam.Lens.OrthographicSize = cutsceneLensSize;

        //Player
        playerController.cutscene = true;
        playerController.Respawn();

        //Potion
        potionSpriteRenderer.sprite = potionSprites[level];

        //Cutscene
        playableDirector.playableAsset = cutscene;
        playableDirector.Play();

        //Canvas
        canvas.SetActive(false);
    }

    public void EndCutscene()
    {
        if (levelManager.levelWon)
        {
            playableDirector.playableAsset = starts[levelManager.currentLevel - 1];
            playableDirector.Play();
        }
        else
        {
            playableDirector.playableAsset = deathCutscene;
            playableDirector.Play();
        }
    }

    public void FreeCamera()
    {
        cineCam.Target.TrackingTarget = player.transform;
        playerController.cutscene = false;
    }
}
