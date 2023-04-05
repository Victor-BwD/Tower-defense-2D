using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCoins : MonoBehaviour
{
    private CoinsGenerate _coinsGenerate;

    // Start is called before the first frame update
    void Start()
    {
        _coinsGenerate = GetComponentInChildren<CoinsGenerate>();
    }

    public bool CheckHowMuchCoins(int coinsNeeded)
    {
        if (coinsNeeded > _coinsGenerate.Coins)
        {
            return false;
        }else if (coinsNeeded <= _coinsGenerate.Coins)
        {
            _coinsGenerate.SpendCoins(coinsNeeded);
            return true;
        }
        return false;
    }
}
