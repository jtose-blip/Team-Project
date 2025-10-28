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
            // Update the camera's position to follow the target horizontally and vertically
            transform.position = new Vector3(target.position.x + xOffset, target.position.y + yOffset, target.position.z + zOffset); 
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}