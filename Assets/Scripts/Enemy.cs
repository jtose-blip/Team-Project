using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody EnemyRb;
    private GameObject player;
    public GameObject enemyPrefab;
    float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRb.AddForce((player.transform.position - transform.position).normalized * speed);

        if (transform.position.y < -1)
        {
            Destroy(enemyPrefab);
        }

        if (transform.position.x >= 8)
        {
           Destroy(enemyPrefab); // if x is greater than 8, the enemy will despawn
        }

        if (transform.position.z >= 17)
        {
           Destroy(enemyPrefab); // if z is greater than 17, the enemy will despawn
        }

        if (transform.position.x <= -8)
        {
            Destroy(enemyPrefab); // if x is less than 8, the enemy will despawn
        }

        if (transform.position.z <= -8)
        {
            Destroy(enemyPrefab); // if z is less than -8, the enemy will despawn
        }
    }
}
