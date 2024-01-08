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

    public Pivot pivot;

    public static bool HasStackedOnGround = false;
    public Vector3 offset;
    
    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        HasStackedOnGround = false;
    }
    
    public void SpawnBunny(BunnyController lastBunny)
    {
        //Instatiate new bunny at the spawn point
        transform.position = Vector3.up * (lastBunny.transform.position.y + offset.y);
        GameObject newBunny = Instantiate(bunnyPrefab, spawnPoint.position, Quaternion.identity);
        pivot.rotationSpeed += 0.1f;
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
