using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody player;
    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis ("Vertical");
        //player.AddForce ;
    }
}
