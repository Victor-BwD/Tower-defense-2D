using System;
using UnityEngine;

public class StartWave : MonoBehaviour
{
    private bool _isClicked;
    
    public Action OnClick;
    private void OnMouseDown()
    {
        if (_isClicked) return; 
        
        OnClick?.Invoke();
        _isClicked = true;
    }
}
