using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-7, 7);
        float spawnY = Random.Range(-7, 7);
        Vector3 RandomPosition = new Vector3(spawnX, spawnY, 0f);
        return RandomPosition;
    }
}
