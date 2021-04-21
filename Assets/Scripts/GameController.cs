using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[] respawns;
    private System.Random random;

    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        random = new System.Random();
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
