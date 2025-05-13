using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Animator animator;
    EnemiesData _data;
    bool _isAlreadyDead = false;
    int _currentHealth;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = _data.clipMove;
        source.Play();
        _currentHealth = _data.maxHealth;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            source.clip = _data.clipDeath;
            source.Play();
        }
        _isAlreadyDead = true;
        animator.SetTrigger("Death");
        StartCoroutine(DestroyAfterAnimation());
        ScoreManager.Instance.ModifyScore(_data.score);
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(Mathf.Max(animator.GetCurrentAnimatorStateInfo(0).length, _data.clipDeath.length));

        Destroy(gameObject);
    }

    public void SetData(EnemiesData data){
        this._data = data;
    }
}
