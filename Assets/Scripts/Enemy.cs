using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    private Rigidbody EnemyRb;
    private GameObject player;
    public GameObject enemyPrefab;
    float speed = 5.0f;
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

        if (transform.position.x >= 10)
        {
           Destroy(enemyPrefab); // if x is greater than 10, the enemy will despawn
        }

        if (transform.position.z >= 100)
        {
           Destroy(enemyPrefab); // if z is greater than 100, the enemy will despawn
        }

        if (transform.position.x <= -10)
        {
            Destroy(enemyPrefab); // if x is less than 10, the enemy will despawn
        }

        if (transform.position.z <= -8)
        {
            Destroy(enemyPrefab); // if z is less than -8, the enemy will despawn
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            EnemyRb.AddForce(Vector3.up * 500f);
        }
    }
}
