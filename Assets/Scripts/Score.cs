using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    private TMP_Text _scoreText;
    

    private int _score;
    private int _highScore;

    public int ActualScore => _score;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _scoreText = GetComponent<TMP_Text>();
        
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void IncreaseScore(int value)
    {
        _score += value;
        _scoreText.text = _score.ToString();
    }
    
    public void UpdateHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            highScoreText.text = _highScore.ToString();
        }
    }

    public void DisplayHighScore()
    {
        highScoreText.text = _highScore.ToString();
    }
}
