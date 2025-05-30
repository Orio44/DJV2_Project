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
    [SerializeField] private UIEnemyLife bar;
    Move moveSc;

    void Start()
    {
        moveSc = GetComponent<Move>();
        source = GetComponent<AudioSource>();
        source.loop = true;
        source.clip = _data.clipMove;
        source.Play();
        _currentHealth = _data.maxHealth;
        animator = transform.Find("Sprite").GetComponent<Animator>();  
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Death();
        }
    }
    public void Damage(int damage){
        bar.gameObject.SetActive(true);
        _currentHealth -= damage;
        bar.UpdateSlider(_data.maxHealth, _currentHealth);
        if (_currentHealth<=0){
            Death();
        }
        if (_data.typeMonster == 4 && _currentHealth<=_data.maxHealth/2){
            moveSc.ChangeSpeed(_data.speed*3);
        }
    }

    public void Death()
    {
        if (_isAlreadyDead){
            return;
        }
        MultiplyerManager.Instance.EnemyKilled();
        WaveManager.Instance.EnemyKilled();
        moveSc.Stop();
        source.clip = _data.clipDeath;
        source.Play();
        _isAlreadyDead = true;
        animator.SetTrigger("Death");
        StartCoroutine(DestroyAfterAnimation());
        ScoreManager.Instance.ModifyScore(_data.score);
        MoneyManager.Instance.EarnMoney(_data.money);
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(Mathf.Max(animator.GetCurrentAnimatorStateInfo(0).length, _data.clipDeath.length));

        Destroy(gameObject);
    }

    public void SetData(EnemiesData data){
        this._data = data;
    }
    public bool IsDead(){
        return _isAlreadyDead;
    }
}
