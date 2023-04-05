using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TowerSlowGun : TowerBase
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float _fireRate;

    private DraggableTowerPlacement _draggable;
    private float _fireCountdown;

    private void Start()
    {
        _draggable = GetComponent<DraggableTowerPlacement>();
        InvokeRepeating("SpawnShoot", 0f, _fireRate);
    }
    
    private void SpawnShoot()
    {
        if (!_draggable.IsMoved) return;
        
        var shoot = Instantiate(prefab, transform.position, quaternion.identity);
        Destroy(shoot, 0.6f);
    }

    public override void IncreaseAttackSpeed(float value)
    {
        _fireRate = (value - 9f);
    }
}
