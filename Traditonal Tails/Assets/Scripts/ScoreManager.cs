using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private Scores scoreData = new Scores();

    void Start()
    {
        scoreData = SaveData.Load();
        scoreData.score = 0;
        UpdateScoreText();
    }

    public void UpdateScore(float height)
    {
        scoreData.score = Mathf.RoundToInt(height);
        UpdateScoreText();

        if (scoreData.score > scoreData.highScore)
        {
            scoreData.highScore = scoreData.score;
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Height: " + scoreData.score + " cm";
    }

    private void OnDestroy()
    {
        SaveData.Save(scoreData);
    }

    private IEnumerator DelayedSave()
    {
        yield return new WaitForSeconds(0f); 
        SaveData.Save(scoreData);
    }
}