using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    int[][][] Waves = new int[][][]
    {
        new int[][] {
            new int[] {5,2,0,0,0,0,0,0},
            new int[] {0,0,0,0,0,0,0,0},
            new int[] {0,0,0,0,0,0,0,0},
            new int[] {0,0,0,0,0,0,0,0}
        },
        new int[][] {
            new int[] {2,2,5,0,0,0,0,0},
            new int[] {5,2,0,0,0,0,0,0},
            new int[] {0,0,0,0,0,0,0,0},
            new int[] {0,0,0,0,0,0,0,0}
        },
        new int[][] {
            new int[] {10,5,10,0,0,0,0,0},
            new int[] {5,5,5,0,2,0,0,0},
            new int[] {0,5,5,10,0,0,0,0},
            new int[] {0,0,0,0,0,0,0,0}
        },
        new int[][] {
            new int[] {20,20,20,0,0,0,0,0},
            new int[] {20,20,0,0,5,0,0,0},
            new int[] {0,10,10,5,0,2,0,0},
            new int[] {0,0,0,0,10,2,0,0}
        },
        new int[][] {
            new int[] {0,0,0,0,5,5,0,0},
            new int[] {20,20,20,20,0,0,0,1},
            new int[] {20,20,20,20,0,0,0,1},
            new int[] {0,0,0,0,5,5,0,0}
        }
    };

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
        if(_enemyRemaining <= 0 && !_buttonactive)
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

    public void EnemyKilled()
    {
        _enemyRemaining--;
        text.UpdateRemainingEnemies();
    }

    public void BeginWave()
    {
        Debug.Log("aaaaah");
        startButton.SetActive(false);
        _buttonactive = false;
        _enemyRemaining = GetNbEnemies(Waves[_waveCount]);
        text.UpdateWave();
        text.UpdateRemainingEnemies();
        StartWaves(_waveCount);
        _waveCount++;
    }

    IEnumerator SpawnWave(int spawnPoint, int [] listEnemies)
    {
        while(true)
        {
            int newEnemy = GetEnemyLeft(listEnemies);
            if (newEnemy == -1){
                break;
            }
            spawner.Spawn(spawnPoint, newEnemy);
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }

    void StartWaves(int i)
    {
        if (i < 0 || i >= Waves.Length)
        {
            Debug.LogWarning("Indice 'i' hors limites.");
            return;
        }

        int[][] wave = Waves[i];

        for (int j = 0; j < wave.Length; j++)
        {
            int[] spawnPoint = wave[j];
            StartCoroutine(SpawnWave(j, spawnPoint));
        }
    }

    int GetEnemyLeft(int[] wave)
    {
        // Récupère tous les indices valides (valeurs > 0)
        List<int> validIndices = new List<int>();
        for (int i = 0; i < wave.Length; i++)
        {
            if (wave[i] > 0)
            {
                validIndices.Add(i);
            }
        }

        if (validIndices.Count == 0)
            return -1; // Tous les éléments sont à 0

        // Tire un indice au hasard
        int randomIndex = validIndices[Random.Range(0, validIndices.Count)];
        wave[randomIndex] -= 1;
        return randomIndex;
    }

    int GetNbEnemies(int[][] array)
{
    int sum = 0;

    foreach (int[] subArray in array)
    {
        foreach (int value in subArray)
        {
            sum += value;
        }
    }

    return sum;
}

    
}
