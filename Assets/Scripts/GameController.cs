using System;
using UnityEngine;
using Mirror;

public class GameController : MonoBehaviour
{
    private const int KILLS_TO_DIVIDIE_TIME = 20;
    private const int KILLS_TO_INCREASE_SPEED = 50;

    private const int FRAME_RATE = 120;
    private static int killCount = 0;
    private static int activeEnemies = 0;

    private GameObject[] respawns;
    private System.Random random;

    public static int ActiveEnemies { get => activeEnemies; set => activeEnemies = value; }

    public static void IncreaseKillCount()
    {
        killCount++;

        if(killCount == KILLS_TO_DIVIDIE_TIME)
        {
            Respawn[] respawns = FindObjectsOfType<Respawn>();

            foreach(Respawn respawn in respawns)
            {
                respawn.DivideRespawnTime();
            }
        }

        if(killCount == KILLS_TO_INCREASE_SPEED)
        {
            Enemy.SpeedIncreased = true;
        }
    }

    public static int GetKillCount()
    {
        return killCount;
    }

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
