using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private int _playerScore;
    [SerializeField] private float _timeLeft;
    [SerializeField] private bool _noTime = false;
    [SerializeField] public bool _gameOver = false;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _clockText;
 

    // Start is called before the first frame update
    void Start()
    {
        _playerScore = 0;
        _timeLeft = 30f;

    }

    // Update is called once per frame
    void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
        }
        _clockText.text = "" + _timeLeft.ToString("0");

        if (_timeLeft <= 0 && _noTime == false)
        {
            _noTime = true;
            GameOver();

        }
    }

    public void UpdateScore()
    {
        _playerScore += 1;
        _scoreText.text = "Score: " + _playerScore.ToString();
    }

    public void GameOver()
    {
        _gameOver = true;
        
    }
}
