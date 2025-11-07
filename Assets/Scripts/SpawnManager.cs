using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign Prefab in inspector
    public GameObject coinPrefab; // Spawns in coin objects
    public float spawnInterval = 30f; // Time (seconds) between a spawn
    private float timer = 0f;
    public int enemyCount = 1; // Number of enemies in the game
    public int coinCount = 5;
    private int score;

    public Vector3 areaSize = new Vector3(10f, 1f, 40f); //width, Height, Depth of the spawn area for the coins  

    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn the first wave of enemies
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        //spawn the coins 
        SpawnCoins();

        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Add the time passed since the last frame

        if (timer >= spawnInterval) // Check if enough time has passed to spawn again
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // Spawn one enemy
            Instantiate(coinPrefab, GenerateSpawnPosition(), coinPrefab.transform.rotation); // Spawn one coin             

            timer = 0f; // Reset the timer
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Instantiate (create) an enemy at a random position
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-7, 7);
        float spawnZ = Random.Range(-7, 109);
        Vector3 RandomPosition = new Vector3(spawnX, 0, spawnZ); // Y = 0 Keeps it on the ground
        return RandomPosition;
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 randomPos = transform.position + new Vector3
                (
                   Random.Range(-areaSize.x / 2, areaSize.x / 2),  // X Range 
                   Random.Range(-areaSize.y / 2, areaSize.y / 2),  // Y Range 
                   Random.Range(-areaSize.z / 2, areaSize.z / 2)   // Z Range 
                );
            Instantiate(coinPrefab, randomPos, coinPrefab.transform.rotation); //coinPrefab.transform.rotation
            Debug.Log($"Spawned coin at {randomPos}");

        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
