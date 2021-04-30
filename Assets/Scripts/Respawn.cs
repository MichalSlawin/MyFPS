using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private int respawnTime = 10;
    [SerializeField] private GameObject enemyPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(respawnTime);
        StartCoroutine(SpawnEnemy());
    }
}
