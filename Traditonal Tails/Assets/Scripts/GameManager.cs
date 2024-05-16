using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject bunnyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Pivot pivot;
    [SerializeField] private Vector3 offset;
    [SerializeField] private ScoreManager scoreManager;

    private float nextSpawnTime;
    private float highestPoint = 0f;
    public static bool HasStackedOnGround = false;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        HasStackedOnGround = false;

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager is not assigned in the Inspector.");
        }

        if (spawnPoint == null)
        {
            Debug.LogError("SpawnPoint is not assigned in the Inspector.");
        }

        if (bunnyPrefab == null)
        {
            Debug.LogError("BunnyPrefab is not assigned in the Inspector.");
        }

        if (pivot == null)
        {
            Debug.LogError("Pivot is not assigned in the Inspector.");
        }
    }

    public void SpawnBunny(BunnyController lastBunny)
    {
        if (lastBunny == null)
        {
            Debug.LogError("LastBunny is null. Cannot spawn new bunny.");
            return;
        }

        transform.position = new Vector3(transform.position.x, lastBunny.transform.position.y + offset.y, transform.position.z);
        GameObject newBunny = Instantiate(bunnyPrefab, spawnPoint.position, Quaternion.identity);
        pivot.rotationSpeed += 0.1f;
    }

    public void BunnyStacked()
    {
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager is not assigned!");
            return;
        }

        Renderer bunnyRenderer = bunnyPrefab.GetComponent<Renderer>();
        if (bunnyRenderer == null)
        {
            Debug.LogError("BunnyPrefab does not have a Renderer component.");
            return;
        }

        float bunnyHeight = bunnyRenderer.bounds.size.y;
        highestPoint += bunnyHeight;
        scoreManager.UpdateScore(highestPoint);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GaameOver");
    }
}
