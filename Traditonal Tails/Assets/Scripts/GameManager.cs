using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    public GameObject bunnyPrefab;
    public Transform spawnPoint;

    public float spawnInterval = 2f;
    public float nextSpawnTime;
    
    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }
    
    public void SpawnBunny()
    {
        //Istatiate new bunny at the spawn point
        GameObject newBunny = Instantiate(bunnyPrefab, spawnPoint.position, Quaternion.identity);
        transform.position += Vector3.up;
    }

    public void BunnyStacked()
    {
        //Called when bunny is successfully stacked
        score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score" + score;
        }
    }
    
}
