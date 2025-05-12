using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    private int _waveCount;
    private int _enemyRemaining;
    private bool _buttonactive;
    [SerializeField] private int growth;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private GameObject startButton;
    [SerializeField] private UIWave text;

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    void Start()
    {
        _waveCount = 0;
        text.UpdateWave();
        text.UpdateRemainingEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyRemaining == 0 && !_buttonactive)
        {
            _buttonactive = true;
            startButton.SetActive(true);
        }
    }

    public int GetWave()
    {
        return _waveCount;
    }

    public int GetRemainingEnemies()
    {
        return _enemyRemaining;
    }

    public void KillEnemy()
    {
        _enemyRemaining--;
        text.UpdateRemainingEnemies();
    }

    public void BegginWave()
    {
        startButton.SetActive(false);
        _buttonactive = false;
        _waveCount++;
        text.UpdateWave();
        _enemyRemaining = growth * _waveCount;
        text.UpdateRemainingEnemies();
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for(int i = 0; i < growth * _waveCount; i++)
        {
            spawner.Spawn(Random.Range(0, spawner.GetNumberOfSpawns()), Random.Range(0, spawner.GetNumberOfEnemies()));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
