using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    [SerializeField] private float slowFactor;

    private void OnTriggerEnter2D(Collider2D col)
    {
        EnemyMovement enemyMovement = col.GetComponent<EnemyMovement>();
        if(enemyMovement && enemyMovement.gameObject.activeSelf) {
            enemyMovement.ApplySlow(slowFactor);
        }
    }
}
