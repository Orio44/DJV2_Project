using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] List<GameObject> EnemiesList = new List<GameObject>();
    
    [SerializeField] List<Transform> SpawnPointList = new List<Transform>();
    // Start is called before the first frame update
    [SerializeField] Transform endingPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Spawn(0,1);
        } if (Input.GetKeyDown(KeyCode.Q))
        {
            Spawn(0,0);
        }
    }

    public void Spawn(int iSpawnPoint, int iEnemy){
        if (iSpawnPoint>=SpawnPointList.Count || iSpawnPoint<0){
            Debug.Log("Invalid iSpawnPoint");
            return;
        }
        if (iEnemy>=SpawnPointList.Count || iEnemy<0){
            Debug.Log("Invalid iEnemy");
            return;
        }
        GameObject newMonsterGO = Instantiate(EnemiesList[iEnemy], SpawnPointList[iSpawnPoint].position, Quaternion.identity);
        Move newMonster = newMonsterGO.GetComponent<Move>();
        newMonster.SetDestination(endingPoint);
    }

    public int GetNumberOfSpawns()
    {
        return SpawnPointList.Count;
    }

    public int GetNumberOfEnemies()
    {
        return EnemiesList.Count;
    }
}
