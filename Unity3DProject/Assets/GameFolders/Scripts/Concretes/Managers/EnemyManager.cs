using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
{
    [SerializeField] int maxCountOnGame = 50;
    [SerializeField] List<EnemyController> enemies;

    public List<Transform> Targets { get; private set; }
    public bool CanSpawn => maxCountOnGame > enemies.Count;
    public bool IsListEmpty => enemies.Count <= 0;

    void Awake()
    {
        SetSingletonThisGameObject(this);
        enemies = new List<EnemyController>();
        Targets = new List<Transform>();
    }

    public void AddEnemyController(EnemyController enemyController)
    {
        enemyController.transform.parent = this.transform;
        enemies.Add(enemyController);
    }

    public void RemoveEnemyController(EnemyController enemyController)
    {
        enemies.Remove(enemyController);
        GameManager.Instance.DecreaseWaveCount();
    }

    public void DestroyAllEnemies()
    {
        foreach (EnemyController enemyController in enemies)
        {
            Destroy(enemyController.gameObject);
        }

        enemies.Clear();
    }
}
