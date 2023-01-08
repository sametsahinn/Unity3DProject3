using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner Info", menuName = "Combat/Spawner Info/Create New")]
public class SpawnInfoScriptableObject : ScriptableObject
{
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] float maxSpawnTime = 15f;
    [SerializeField] float minSpawnTime = 3f;

    public EnemyController EnemyPrefab => enemyPrefab;
    public float RandomSpawnMaxTime => Random.Range(minSpawnTime, maxSpawnTime);
}
