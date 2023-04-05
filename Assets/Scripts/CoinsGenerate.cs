using System;
using TMPro;
using UnityEngine;

public class CoinsGenerate : MonoBehaviour
{
    private TMP_Text _coinText;

    private int _coins = 160;

    private StartWave _startWave;
    
    public int Coins => _coins;

    private void Start()
    {
        _coinText = GetComponent<TMP_Text>();
        _startWave = FindObjectOfType<StartWave>();
        
        _coinText.text = _coins.ToString();

        _startWave.OnClick += StartGenerateCoins;
    }

    private void StartGenerateCoins()
    {
        InvokeRepeating("CoinsForTime", 0f, 0.2f);
    }

    private void CoinsForTime()
    {
        _coins++;
        _coinText.text = _coins.ToString();
    }

    public void SpendCoins(int value)
    {
        _coins -= value;
        _coinText.text = _coins.ToString(); // atualiza o texto das moedas
    }

    public void IncreaseCoins(int value)
    {
        _coins += value;
        _coinText.text = _coins.ToString();
    }
}
