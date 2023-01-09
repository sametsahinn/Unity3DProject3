using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] int waveLevel = 1;
    [SerializeField] float waitNextLevel = 10f;
    [SerializeField] float waveMultiple = 1.2f;
    [SerializeField] int maxWaveBoundaryCount = 50;
    [SerializeField] int playerCount = 0;

    int currentWaveMaxCount;
    public int PlayerCount => playerCount;

    public event System.Action<int> OnNextWave;

    public bool IsWaveFinished => currentWaveMaxCount <= 0;

    void Awake()
    {
        SetSingletonThisGameObject(this);
    }

    void Start()
    {
        currentWaveMaxCount = maxWaveBoundaryCount;
    }

    public void LoadLevel(string name)
    {
        StartCoroutine(LoadLevelAsync(name));
    }

    private IEnumerator LoadLevelAsync(string name)
    {
        yield return SceneManager.LoadSceneAsync(name);
    }

    public void DecreaseWaveCount()
    {
        if (IsWaveFinished)
        {
            if (EnemyManager.Instance.IsListEmpty)
            {
                StartCoroutine(StartNextWaveAsync());
            }
        }
        else
        {
            currentWaveMaxCount--;
        }
    }

    private IEnumerator StartNextWaveAsync()
    {
        yield return new WaitForSeconds(waitNextLevel);
        maxWaveBoundaryCount = System.Convert.ToInt32(maxWaveBoundaryCount * waveMultiple);
        currentWaveMaxCount = maxWaveBoundaryCount;
        waveLevel++;
        OnNextWave?.Invoke(waveLevel);
    }

    public void IncreasePlayerCount()
    {
        playerCount++;
    }

    public void ReturnMenu()
    {
        if (playerCount > 1)
        {
            playerCount--;
        }
        else
        {
            playerCount = 0;
            EnemyManager.Instance.DestroyAllEnemies();
            EnemyManager.Instance.Targets.Clear();
            LoadLevel("Menu");
        }
    }
}
