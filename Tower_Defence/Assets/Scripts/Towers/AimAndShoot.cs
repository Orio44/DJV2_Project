using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    [SerializeField] TowerData data;
    [SerializeField] GameObject weaponGO;
    Weapon _weapon;
    int _level;
    // Start is called before the first frame update
    void Start()
    {
        _level = 0;
        _weapon = weaponGO.GetComponent<Weapon>();
        _weapon.SetData(data);
        StartCoroutine(SlowUpdate(data.AttackCooldown[_level]));
    }

    public void Upgrade(){
        _level++;
        _weapon.Upgrade();
    }

    IEnumerator SlowUpdate(float time){
        while (true){
            LookForEnemies();
            yield return new WaitForSeconds(time);
        }
    }

    void LookForEnemies()
    {
        GameObject closest = GetClosestEnemy(transform.position, data.Range[_level], data.maskToShoot);
        if (closest != null){
            _weapon.Attack(closest);
        }
    }

    public GameObject GetClosestEnemy(Vector3 center, float radius, LayerMask layerMask = default)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius, layerMask);
        Collider2D closest = null;
        float minDistance = float.MaxValue;

        foreach (Collider2D col in colliders)
        {
            Vector2 closestPoint = col.ClosestPoint(center);
            float distance = Vector2.Distance(center, closestPoint);
            if (!col.gameObject.GetComponent<Health>().IsDead() && distance < minDistance)
            {
                minDistance = distance;
                closest = col;
            }
        }

        if (closest == null){
            return null;
        }
        return closest.gameObject;
    }
}
