using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;

    public GameObject bunnyPrefab;
    public Transform spawnPoint;

    public float spawnInterval = 2f;
    public float nextSpawnTime;

    public static bool HasStackedOnGround = false;
    
    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        HasStackedOnGround = false;
    }
    
    public void SpawnBunny()
    {
        //Instatiate new bunny at the spawn point
        transform.position += Vector3.up;
        GameObject newBunny = Instantiate(bunnyPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void BunnyStacked()
    {
        //Called when bunny is successfully stacked
        score++;
        UpdateScoreUI();
    }

    public int Score
    {
        get { return score; }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = " Score: " + score;
        }
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene("GaameOver");
    }
    
}
