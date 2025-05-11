using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerSO data;
    [SerializeField] private GameObject projectile;
    private int _level;
    // Start is called before the first frame update
    void Start()
    {
        _level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
    }

    private void LevelUp()
    {
        _level++;
        MoneyManager.Instance.BuyTower(data.Cost[_level]);
    }

    public float getProjectileSpeed()
    {
        return data.ProjectileSpeed[_level];
    }

    public int getDamage()
    {
        return data.ProjectileDamage[_level];
    }
}
