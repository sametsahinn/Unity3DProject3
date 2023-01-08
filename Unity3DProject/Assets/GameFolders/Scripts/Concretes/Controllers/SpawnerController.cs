using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] SpawnInfoScriptableObject spawnInfo;
    [SerializeField] float maxTime;

    float currentTime = 0f;

    void Start()
    {
        maxTime = spawnInfo.RandomSpawnMaxTime;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > maxTime) //&& EnemyManager.Instance.CanSpawn && !GameManager.Instance.IsWaveFinished
        {
            Spawn();
        }
    }

    void Spawn()
    {
        EnemyController enemyController = Instantiate(spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);
        // EnemyManager.Instance.AddEnemyController(enemyController);

        currentTime = 0f;
        maxTime = spawnInfo.RandomSpawnMaxTime;
    }
}
