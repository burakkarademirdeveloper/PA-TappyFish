using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int _score;

    private Text _scoreText;
    void Start()
    {
        _score = 0;
        _scoreText = GetComponent<Text>();
        _scoreText.text = _score.ToString();
    }

    public void Scored()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
