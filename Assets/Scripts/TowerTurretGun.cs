using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTurretGun : TowerBase
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject _bulletPrefab;
    
    private Transform _target;
    private float _fireCountdown = 0f;
    private DraggableTowerPlacement _draggableTowerPlacement;

    private void Start()
    {
        _draggableTowerPlacement = FindObjectOfType<DraggableTowerPlacement>();
    }

    private void Update()
    {
        FindTarget();
        
        TryShoot();
    }

    public override void FindTarget()
    {
        if (_draggableTowerPlacement.IsDragging) return;
        
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _range, _enemyLayer);

        if (enemies.Length > 0)
        {
            _target = enemies[0].transform;
        }
        else
        {
            _target = null;
        }
    }

    public override void TryShoot()
    {
        if (!ReferenceEquals(_target, null))
        {
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / _fireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    public override void Shoot()
    {
        GameObject bulletInstance = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        Bullet bullet = bulletInstance.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    public override void IncreaseAttackSpeed(float value)
    {
        _fireRate = value;
    }
}
