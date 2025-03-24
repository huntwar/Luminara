using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;  // Drag your player character here in the Inspector
    public float smoothSpeed = 5f;
    public float zOffset = -10f; // Fixed Z position for the camera

    void LateUpdate()
    {
        if (target == null) return;

        // Calculate the desired position with the offset
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, zOffset);

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
