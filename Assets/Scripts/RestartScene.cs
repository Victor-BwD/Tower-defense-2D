using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Scene1");
        Time.timeScale = 1;
    }
}
