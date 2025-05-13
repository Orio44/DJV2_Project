using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{

    [SerializeField] Transform target = null;
    EnemiesData data;

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
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                MultiplyerManager.Instance.EnemyPassed();
                Debug.Log("Agent est arrivé !");
                //Destroy(gameObject);
            }
        }
    }

    public void SetDestination(Transform target){
        this.target = target;
    }

    public void SetData(EnemiesData data){
        this.data = data;
        agent.speed = data.speed;
    }

    public void Stop(){
        agent.isStopped = true;
    }
}
