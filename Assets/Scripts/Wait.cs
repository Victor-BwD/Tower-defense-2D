using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public static async Task WaitTime(float seconds)
    {
        await Task.Delay(Mathf.RoundToInt(seconds * 1000));
    }
}
