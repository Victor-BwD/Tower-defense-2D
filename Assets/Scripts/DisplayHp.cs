using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DisplayHp : MonoBehaviour
    {
        private TMP_Text _hpText;
        
        private void Start()
        {
            _hpText = GetComponent<TMP_Text>();
        }

        public void ShowHp(int value)
        {
            _hpText.text = value.ToString();
        }
    }
}