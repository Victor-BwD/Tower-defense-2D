using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateItemShop : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private int coinsNeededToPurchase;

    private DraggableTowerPlacement _currentDraggableTowerPlacement;
    private CheckCoins _check;
    private CheckNumberOfTowers _checkNumberOfTowers;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _check = FindObjectOfType<CheckCoins>();
        _checkNumberOfTowers = FindObjectOfType<CheckNumberOfTowers>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private async void OnMouseDown()
    {
        if (_check.CheckHowMuchCoins(coinsNeededToPurchase))
        {
            var spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = -0.20f;
            var instance = Instantiate(towerPrefab, spawnPosition, Quaternion.identity);
            _currentDraggableTowerPlacement = instance.GetComponent<DraggableTowerPlacement>();
            _currentDraggableTowerPlacement.HandleMouseDown();
            DisableObject();
            
            _checkNumberOfTowers.TowerBuilt();
            if (_checkNumberOfTowers.ReachMaximumTowers) return;
            
            await Wait.WaitTime(0.7f);
            
            EnableObject();
        }
        else
        {
            _spriteRenderer.color = Color.red;

            await Wait.WaitTime(0.4f);
            
            _spriteRenderer.color = Color.white;
        }
    }
    
    private void OnMouseDrag()
    {
        if (_currentDraggableTowerPlacement != null)
        {
            _currentDraggableTowerPlacement.HandleMouseDown();
        }
    }

    private void OnMouseUp()
    {
        if (_currentDraggableTowerPlacement != null)
        {
            _currentDraggableTowerPlacement.OnMouseUp();
        }
    }

    private void EnableObject()
    {
        this.gameObject.SetActive(true);
    }

    private void DisableObject()
    {
        this.gameObject.SetActive(false);
    }
}
