using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody EnemyRb;
    private GameObject player;
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
    }
}
