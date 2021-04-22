using System;
using UnityEngine;
using Mirror;

public class GameController : MonoBehaviour
{
    private const int FRAME_RATE = 120;

    private GameObject[] respawns;
    private System.Random random;

    void Start()
    {
        Application.targetFrameRate = FRAME_RATE;

        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        random = new System.Random();

        NetworkManagerHUD hud = FindObjectOfType<NetworkManagerHUD>();
        if (hud != null)
            hud.enabled = false;
    }

    public void RespawnPlayerRandom(GameObject player)
    {
        int rndNum = random.Next(0, respawns.Length);
        Vector3 respawnPosition = respawns[rndNum].transform.position;
        CharacterController characterController = player.GetComponent<CharacterController>();
        characterController.enabled = false;
        player.transform.position = respawnPosition;
        player.GetComponent<Player>().SetStartHp();
        characterController.enabled = true;
    }
}
