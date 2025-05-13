using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{

    [SerializeField] Transform target = null;
    EnemiesData _data;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null){
            agent.SetDestination(target.position);
            if (!agent.pathPending && agent.remainingDistance <= 5f && !agent.hasPath)
            {
                MultiplyerManager.Instance.EnemyPassed();
                WaveManager.Instance.EnemyKilled();
                ScoreManager.Instance.ModifyScore(_data.score);
                Destroy(gameObject);
            }
        }
    }

    public void SetDestination(Transform target){
        this.target = target;
    }
    public Transform GetDestination(){
        return target;
    }

    public void SetData(EnemiesData data){
        _data = data;
        agent.speed = data.speed;
    }

    public void Stop(){
        agent.isStopped = true;
    }
    public void Resume(){
        agent.isStopped = false;
    }

    public void ChangeSpeed(float speed){
        Debug.Log("speeeeed");
        agent.speed = speed;
    }
}
