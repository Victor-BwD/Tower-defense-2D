using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Goal _goal;
    [SerializeField] private GameObject _gameOverObject;
    [SerializeField] private GameObject _maxScore;

    private Score _score;
    
    void Start()
    {
        _goal = FindObjectOfType<Goal>();
        _goal.AddDeathListener(HandlePlayerDeath);

        _score = FindObjectOfType<Score>();
    }
    private void HandlePlayerDeath()
    {
        _gameOverObject.SetActive(true);
        _maxScore.SetActive(true);
        _score.UpdateHighScore();
        _score.DisplayHighScore();

        Time.timeScale = 0;
    }
}
