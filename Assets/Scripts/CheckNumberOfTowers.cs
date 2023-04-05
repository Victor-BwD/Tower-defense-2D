using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNumberOfTowers : MonoBehaviour
{
    public int maxTowers = 5; 
    private int currentTowers = 0;
    private bool _reachMaximum;

    private InstantiateItemShop[] _instantiateItemShops;

    public bool ReachMaximumTowers => _reachMaximum;
    
    public void TowerBuilt()
    {
        currentTowers++;
        if (currentTowers >= maxTowers)
        {
            // desabilitar a possibilidade de construir mais torres aqui
            _reachMaximum = true;
            _instantiateItemShops = FindObjectsOfType<InstantiateItemShop>();
            foreach (var instantiateItemShop in _instantiateItemShops)
            {
                instantiateItemShop.gameObject.SetActive(false);
            }
        }
    }
}
