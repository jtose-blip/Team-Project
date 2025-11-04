using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    private GameObject focalPoint;
    private Rigidbody player;
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public bool onGround = true;
    public bool hasCollectable;
    private SpawnManager spawnManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis ("Vertical");
        player.AddForce(Vector3.forward * speed * forwardInput);
        float horizontalInput = Input.GetAxis ("Horizontal");
        player.AddForce(focalPoint.transform.right * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            // this code ensure that the player can jump up and yet control the object like a ball still due to the AddForce.
            // The line below ensures that a player can onlu jump AFTER they hit the ground
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            hasCollectable = true;
            Destroy(other.gameObject);

            spawnManager.UpdateScore(5);
        }
    }
}
