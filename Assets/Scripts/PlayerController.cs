using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameObject focalPoint;
    private Rigidbody player;
    public float speed = 5.0f;
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

    }
}
