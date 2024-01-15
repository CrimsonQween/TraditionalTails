using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private Scores scoreData = new Scores();

    void Start()
    {
        scoreData = SaveData.Load();
        scoreData.score = 0;
        UpdateScoreText();
    }

    public void IncreaseScore(int points)
    {
        // Normal Scoring
        scoreData.score += points;
        UpdateScoreText();

        // High Score
        if (scoreData.score > scoreData.highScore)
        {
            scoreData.highScore = scoreData.score;
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreData.score;
    }
    
    


    private void OnDestroy()
    {
        SaveData.Save(scoreData);
    }
}
