using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxis ("Horizontal");
        //This makes the camera rotate on the horizontal access on the Focal Point with a determined speed
        //transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
