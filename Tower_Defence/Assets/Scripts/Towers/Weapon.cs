using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectileModel;
    TowerData _data;
    int _level;
    
    void Start(){
        _level = 0;
    }
    public void Attack(GameObject target){
        GameObject newProjectileGO = Instantiate(projectileModel, transform.position, transform.rotation);
        Projectile newProjectile = newProjectileGO.GetComponent<Projectile>();
        newProjectile.SetData(_data);
        newProjectile.SetLevel(_level);
        newProjectile.SetTarget(target);
    }

    public void SetData(TowerData data){
        _data = data;
    }

    public void Upgrade(){
        _level++;
    }
}
