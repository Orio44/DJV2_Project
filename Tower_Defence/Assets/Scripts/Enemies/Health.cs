using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Animator animator;
    EnemiesData data;
    bool _isAlreadyDead = false;
    int _currentHealth;

    void Start()
    {
        _currentHealth = data.maxHealth;
        animator = transform.Find("Sprite").GetComponent<Animator>();  
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Death();
        }
    }
    public void Damage(int damage){
        _currentHealth -= damage;
        if (_currentHealth<=0){
            Death();
        }
    }

    public void Death()
    {
        if (_isAlreadyDead){
            return;
        }
        _isAlreadyDead = true;
        animator.SetTrigger("Death");
        StartCoroutine(DestroyAfterAnimation());
        ScoreManager.Instance.ModifyScore(data.score);
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject);
    }

    public void SetData(EnemiesData data){
        this.data = data;
    }
}
