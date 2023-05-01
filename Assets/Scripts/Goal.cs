using System;
using DefaultNamespace;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private int _maxHealthPoints = 100;
    private int _actualHealthPoints;
    
    private Action _onDeath;

    [SerializeField]private DisplayHp _displayHp;

    public int MaxHealthPoints => _maxHealthPoints;

    public void AddDeathListener(Action listener)
    {
        _onDeath += listener;
    }

    private void Start()
    {
        _actualHealthPoints = _maxHealthPoints;
    }

    public void TakeDamage(int damage)
    {
        _actualHealthPoints -= damage;
        _displayHp.ShowHp(_actualHealthPoints);
        
        if (_actualHealthPoints <= 0)
        {
            _actualHealthPoints = 0;
            _onDeath?.Invoke();
        }
    }
}
