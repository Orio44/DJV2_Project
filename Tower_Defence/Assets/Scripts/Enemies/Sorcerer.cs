using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : MonoBehaviour
{
    [SerializeField] float cooldown;
    float _timer;
    [SerializeField] GameObject wolf;
    Move _moveSc;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    { 
        animator = transform.Find("Sprite").GetComponent<Animator>();
        _moveSc = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer+=Time.deltaTime;
        if (_timer>cooldown){
            _timer = -10000f;
            StartCoroutine(SpawnWolf());
        }
    }

    IEnumerator SpawnWolf(){
        _moveSc.Stop();
        animator.SetTrigger("Spawn");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        GameObject newWolf = Instantiate(wolf, transform);
        newWolf.GetComponent<Move>().SetDestination(_moveSc.GetDestination());
        _moveSc.Resume();
        _timer = 0f;
    }
}
