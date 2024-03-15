using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothing speed for camera movement
    public Vector3 offset; // Offset of the camera from the player

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset; // Calculate desired camera position

            // Smoothly interpolate between current position and desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            smoothedPosition.z = -10;
            // Update camera's position
            transform.position = smoothedPosition;
            
        }
    }
}
