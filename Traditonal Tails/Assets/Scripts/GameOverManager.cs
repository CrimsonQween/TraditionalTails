using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text scoreText;
    public TMP_Text highScore;

    void Start()
    {
        Scores scoreData = SaveData.Load();
        Debug.Log(scoreData);
        gameOverText.text = "Game Over!";
        scoreText.text = "Score: " + scoreData.score;
        highScore.text = "High Score: " + scoreData.highScore;
    }
}