using System;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask _layerToCollideWith;
    [SerializeField] private int _damage;
    [SerializeField] private float _enemyHealth;
    [SerializeField] private int _killReward;
    [SerializeField] private int _scoreReceive;

    private Goal _goal;
    private CoinsGenerate _increaseCoins;
    private Score _score;
    
    private void Start()
    {
        _goal = FindObjectOfType<Goal>();
        _increaseCoins = FindObjectOfType<CoinsGenerate>();
        _score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_layerToCollideWith == (_layerToCollideWith | (1 << col.gameObject.layer)))
        {
            // Faça algo quando ocorrer uma colisão com a layer desejada
            _goal.TakeDamage(_damage);
        }
    }
    
    private void OnEnemyDestroyed()
    {
        _enemyHealth = 0;
        _score.IncreaseScore(_scoreReceive);
        _increaseCoins.IncreaseCoins(_killReward);
        Destroy(gameObject);
    }
    
    public void TakeDamage(int damage)
    {
        _enemyHealth -= damage;
        if (_enemyHealth <= 0)
        {
            OnEnemyDestroyed();
        }
    }
}
