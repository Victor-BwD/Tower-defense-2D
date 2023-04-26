using System;
using DefaultNamespace;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private int _maxHealthPoints = 100;
    private int _actualHealthPoints;
    
    private Action _onDeath;

    private DisplayHp _displayHp;

    public void AddDeathListener(Action listener)
    {
        _onDeath += listener;
    }

    private void Start()
    {
        _actualHealthPoints = _maxHealthPoints;
        _displayHp = FindObjectOfType<DisplayHp>();
        
        _displayHp.ShowHp(_actualHealthPoints);
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
