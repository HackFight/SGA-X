using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ScriptedAnimations : MonoBehaviour
{
    //Cam
    CinemachineCamera cineCam;
    public Transform custsceneCameraTarget;

    //Player
    GameObject player;
    PlayerController playerController;

    //Other
    public List<Sprite> potionSprites = new List<Sprite>();

    private void Start()
    {
        cineCam = GameObject.FindWithTag("CinemachineCamera").GetComponent<CinemachineCamera>();

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    public void PlayCutscene(int level)
    {
        cineCam.Target.TrackingTarget = custsceneCameraTarget;
        playerController.cutscene = true;
        playerController.Respawn();
    }
}
