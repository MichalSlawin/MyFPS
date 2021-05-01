using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private const int TIME_DIVIDER = 2;
    private const int MAX_ACTIVE = 100;

    [SerializeField] private int respawnTime = 10;
    [SerializeField] private GameObject enemyPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        if(GameController.ActiveEnemies < MAX_ACTIVE) Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(respawnTime);
        StartCoroutine(SpawnEnemy());
    }

    public void DivideRespawnTime()
    {
        respawnTime /= TIME_DIVIDER;
    }
}
