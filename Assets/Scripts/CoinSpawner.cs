using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 3f;

    // Define the spawn area
    public Vector3 spawnMin = new Vector3(-8f, 1f, -58f);
    public Vector3 spawnMax = new Vector3(8f, 5f, 58f);

    private void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnMin.x, spawnMax.x),
            Random.Range(spawnMin.y, spawnMax.y),
            Random.Range(spawnMin.z, spawnMax.z)
        );

        Instantiate(coinPrefab, randomPosition, Quaternion.identity);
    }
}


