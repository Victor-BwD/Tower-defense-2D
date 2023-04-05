using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuffZone : MonoBehaviour
{
    [SerializeField] private float attackSpeedMultiplier;
    [SerializeField] private LayerMask towerLayer;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (towerLayer == (towerLayer | (1 << other.gameObject.layer)))
        {
            TowerBase tower = other.GetComponent<TowerBase>();
            if (tower != null)
            {
                tower.IncreaseAttackSpeed(attackSpeedMultiplier);
            }
        }
    }
}
