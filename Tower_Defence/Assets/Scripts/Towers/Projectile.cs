using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject _target;
    Vector3 _posTarget;
    TowerData _data;
    int _level;
    
    bool hasImpacted = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.Find("Sprite").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasImpacted){
            return;
        }
        if (_posTarget == null){
            return;
        }
        Vector3 direction;
        switch (_data.projectileType){
            case 0:
                if ((_posTarget - transform.position).sqrMagnitude<0.1f){
                    if (_target!=null){
                        _target.GetComponent<Health>().Damage(_data.ProjectileDamage[_level]);
                    }
                    animator.SetTrigger("Impact");
                    hasImpacted = true;
                }
                LookAt(_posTarget);
                direction = Vector3.MoveTowards(transform.position, _posTarget, _data.ProjectileSpeed[_level] * Time.deltaTime);
                transform.position = direction;
                if (_target != null){
                    _posTarget = _target.transform.position;
                }
                break;
            case 1:
                if ((_posTarget - transform.position).sqrMagnitude<0.1f){
                    Explode();
                    animator.SetTrigger("Impact");
                    hasImpacted = true;
                }
                direction = Vector3.MoveTowards(transform.position, _posTarget, _data.ProjectileSpeed[_level] * Time.deltaTime);
                transform.position = direction;
                break;
            case 2:
                Explode();
                animator.SetTrigger("Impact");
                hasImpacted = true;
                break;
            case 3:
                if ((_posTarget - transform.position).sqrMagnitude<0.1f){
                    if (_target!=null){
                        _target.GetComponent<Health>().Damage(_data.ProjectileDamage[_level]);
                    }
                    animator.SetTrigger("Impact");
                    hasImpacted = true;
                }
                direction = Vector3.MoveTowards(transform.position, _posTarget, _data.ProjectileSpeed[_level] * Time.deltaTime);
                transform.position = direction;
                if (_target != null){
                    _posTarget = _target.transform.position;
                }
                break;
            default:
                break;
        }
    }

    void LookAt(Vector3 target){
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    void Explode(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _data.AOE[_level], _data.maskToShoot);

        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.TryGetComponent<Health>(out var health)){
                health.Damage(_data.ProjectileDamage[_level]);
            }
        }
    }
                    
    public void SetTarget(GameObject target){
        _target = target;
        _posTarget = target.transform.position;
    }

    public void SetData(TowerData data){
        _data = data;
    }

    public void SetLevel(int level){
        _level = level;
    }

    
}
