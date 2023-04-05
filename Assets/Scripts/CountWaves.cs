using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountWaves : MonoBehaviour
{
    private TMP_Text _waveText;
    private int _waveNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        _waveText = GetComponent<TMP_Text>();
    }

    public void ChangeWaveNumber(int value)
    {
        _waveNumber = value;
        _waveText.text = _waveNumber.ToString();
    }
}
