using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign Prefab in inspector
    public GameObject coinPrefab; // Spawns in coin objects
    public float spawnInterval = 3f; // Time (seconds) between a spawn
    private float timer = 0f;
    public int enemyCount = 1; // Number of enemies in the game
    public int coinCount = 1;
    private int score;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn the first wave of enemies
        SpawnEnemyWave(enemyCount);
        SpawnCollectable(coinCount);

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Add the time passed since the last frame

        if (timer >= spawnInterval) // Check if enough time has passed to spawn again
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // Spawn one enemy

            timer = 0f; // Reset the timer
        }

        if (timer >= spawnInterval) // Check if enough time has passed to spawn again
        {
            Instantiate(coinPrefab, GenerateSpawnPosition(), coinPrefab.transform.rotation); // Spawn one enemy

            timer = 0f; // Reset the timer
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Instantiate (create) an enemy at a random position
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            UpdateScore(5);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-7, 7);
        float spawnZ = Random.Range(-7, 7);
        Vector3 RandomPosition = new Vector3(spawnX, 0, spawnZ); // Y = 0 Keeps it on the ground
        return RandomPosition;
    }

    void SpawnCollectable(int coinsToSpawn)
    {
        for (int i = 0; i < coinsToSpawn; i++)
        {
            Instantiate(coinPrefab, GenerateSpawnPosition(), coinPrefab.transform.rotation);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Coins: " + score;
    }
}
