using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DisplayHp : MonoBehaviour
    {
        private TMP_Text _hpText;
        private Goal _goal;
        
        private void Start()
        {
            _hpText = GetComponent<TMP_Text>();
            _goal = FindObjectOfType<Goal>();
            
            ShowHp(_goal.MaxHealthPoints);
        }

        public void ShowHp(int value)
        {
            if (ReferenceEquals(_hpText, null)) return;
            
            _hpText.text = value.ToString();
        }
    }
}