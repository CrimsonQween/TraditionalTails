using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text scoreText;

    void Start()
    {
        // Set initial values or retrieve them from another script
        gameOverText.text = "Game Over!";
        scoreText.text = "Score: 0";
    }

    // You can use this method to update the score
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}