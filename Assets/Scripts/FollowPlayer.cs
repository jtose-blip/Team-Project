using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object to follow
    public float yOffset = 5f; // Vertical offset from the target
    public float xOffset = 5f; // Horizontal offset from the target
    public float zOffset = -10f; // Depth offset from the target
    void Update()
    {
        if (target != null)
        {
            // Update the camera's position to follow the target horizontally
            transform.position = new Vector3(target.position.x, yOffset, zOffset);
        }

        else
        {
            // Update the camera's position to follow the target vertically
            transform.position = new Vector3(xOffset, target.position.y, zOffset);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
}