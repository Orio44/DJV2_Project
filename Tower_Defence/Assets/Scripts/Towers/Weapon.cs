using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Camera _mainCamera;
    private float _mousePositionOnPlane;
    private Plane _plane;
    [SerializeField] GameObject ui;
    [SerializeField] TextMeshProUGUI upgradeText;

    [SerializeField] GameObject projectileModel;
    TowerData _data;
    int _level;
    Animator animator;
    GameObject _currentTarget;
    
    void Start()
    {
        _mainCamera = Camera.main;
        _plane = new Plane(Vector3.up, Vector3.zero);
        animator = GetComponent<Animator>();
        _level = 0;
    }

    void Update(){
        if (_currentTarget != null){
            
            if (Vector3.Distance(_currentTarget.transform.position, transform.position)<_data.Range[_level]){
                LookAt(_currentTarget.transform.position);
            }
        }
        if (SelectTile())
        {
            if (Input.GetMouseButtonDown(0) && _level < 2)
            {
                ui.SetActive(true);
                upgradeText.text = "" + _data.Cost[_level + 1];
            }
        }
    }
    public void CloseUI()
    {
        ui.SetActive(false);
    }
    public void Attack(GameObject target){
        _currentTarget = target;
        if (animator == null){
            animator = GetComponent<Animator>();
        }
        animator.SetTrigger("Attack");
    }

    public void CreateProjectile(){
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
        if (MoneyManager.Instance.GetMoney() < _data.Cost[_level + 1]) return;
        MoneyManager.Instance.BuyTower(_data.Cost[_level + 1]);
        _level++;
        ui.SetActive(false);
    }
    
    void LookAt(Vector3 target){
        if (_data.projectileType == 2){
            return;
        }
        Vector3 dir = target - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    private bool SelectTile()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        _plane.Raycast(ray, out _mousePositionOnPlane);
        float xMousePosition = ray.GetPoint(_mousePositionOnPlane).x;
        float yMousePosition = ray.GetPoint(_mousePositionOnPlane).y;
        bool isInTileX = transform.position.x - transform.localScale.x < xMousePosition && xMousePosition < transform.position.x + transform.localScale.x;
        bool isInTileY = transform.position.y - transform.localScale.y < yMousePosition && yMousePosition < transform.position.y + transform.localScale.y;
        return isInTileX && isInTileY;
    }
}
