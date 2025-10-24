using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameObject focalPoint;
    private Rigidbody player;
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public bool onGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis ("Vertical");
        player.AddForce (focalPoint.transform.forward * speed * forwardInput);
        float horizontalInput = Input.GetAxis ("Horizontal");
        player.AddForce(focalPoint.transform.right * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            // this code ensure that the player can jump up and yet control the object like a ball still due to the AddForce.
            // The line below ensures that a player can onlu jump AFTER they hit the ground
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"));
        {
            onGround = true;
        }
    }
}
