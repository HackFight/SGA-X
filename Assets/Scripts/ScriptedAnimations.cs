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

    //Player
    GameObject player;
    PlayerController playerController;

    //Timeline
    PlayableDirector playableDirector;
    [SerializeField] List<TimelineAsset> cutscenes = new List<TimelineAsset>();
    [SerializeField] TimelineAsset deathCutscene;
    [SerializeField] TimelineAsset winCutscene;

    //Cauldron
    public SpriteRenderer potionSpriteRenderer;
    public List<Sprite> potionSprites = new List<Sprite>();

    //Other
    LevelManager levelManager;

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
        playableDirector.playableAsset = cutscenes[level];
        cineCam.Target.TrackingTarget = custsceneCameraTarget;
        playerController.cutscene = true;
        playerController.Respawn();
        potionSpriteRenderer.sprite = potionSprites[level];
        playableDirector.Play();
    }

    public void EndCutscene()
    {
        if (levelManager.levelWon)
        {
            playableDirector.playableAsset = winCutscene;
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
