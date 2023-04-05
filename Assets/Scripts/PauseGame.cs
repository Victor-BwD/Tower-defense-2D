using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void OnMouseDown()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // continua o tempo
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f; // pausa o tempo
            isPaused = true;
        }
    }
}
