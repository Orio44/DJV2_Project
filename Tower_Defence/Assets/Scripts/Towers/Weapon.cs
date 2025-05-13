using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectileModel;
    TowerData _data;
    int _level;
    Animator animator;
    GameObject _currentTarget;
    
    void Start(){
        animator = GetComponent<Animator>();
        _level = 0;
    }

    void Update(){
        Debug.Log(_currentTarget);
        if (_currentTarget != null){
            
            Debug.Log("Valeurs : a = " + (Vector3.Distance(_currentTarget.transform.position, transform.position)) + ", b = " + (_currentTarget.transform.position)+transform.position);
            if (Vector3.Distance(_currentTarget.transform.position, transform.position)<_data.Range[_level]){
                LookAt(_currentTarget.transform.position);
            }
        }
    }
    public void Attack(GameObject target){
        _currentTarget = target;
        animator.SetTrigger("Attack");
    }

    public void CreateProjectile(){
        Debug.Log("coucou");
        if (_currentTarget == null){
            return;
        }
        GameObject newProjectileGO = Instantiate(projectileModel, transform.position, transform.rotation);
        Projectile newProjectile = newProjectileGO.GetComponent<Projectile>();
        newProjectile.SetData(_data);
        newProjectile.SetLevel(_level);
        newProjectile.SetTarget(_currentTarget);
    }

    public void SetData(TowerData data){
        _data = data;
    }

    public void Upgrade(){
        _level++;
    }
    
    void LookAt(Vector3 target){
        if (_data.projectileType == 2){
            return;
        }
        Vector3 dir = target - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
