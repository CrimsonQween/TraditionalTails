using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScore;

    void Start()
    {
        Scores scoreData = SaveData.Load();
        Debug.Log(scoreData);
        gameOverText.text = "Game Over!";
        scoreText.text = "Height: " + scoreData.score + " cm";
        highScore.text = "High Score: " + scoreData.highScore + " cm";
    }
}