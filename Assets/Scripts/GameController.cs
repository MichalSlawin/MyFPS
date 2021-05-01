using System;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private const int KILLS_TO_DIVIDIE_TIME = 20;
    private const int KILLS_TO_INCREASE_SPEED = 50;

    private const int FRAME_RATE = 120;
    private static int killCount = 0;
    private static int activeEnemies = 0;
    private UIController uIController;
    private bool gameEnded = false;

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

    public void EndGame()
    {
        uIController.SetLoseText(killCount);
        gameEnded = true;
        Time.timeScale = 0;
    }

    private void RestartGame()
    {
        activeEnemies = 0;
        killCount = 0;
        Enemy.SpeedIncreased = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        Application.targetFrameRate = FRAME_RATE;

        uIController = FindObjectOfType<UIController>();

        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        random = new System.Random();

        NetworkManagerHUD hud = FindObjectOfType<NetworkManagerHUD>();
        if (hud != null)
            hud.enabled = false;
    }

    private void Update()
    {
        if(gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
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
