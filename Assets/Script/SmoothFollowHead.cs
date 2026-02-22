using UnityEngine;

public class SmoothFollowHead : MonoBehaviour
{
    public Transform headCamera;      // Assign CenterEyeAnchor or Main Camera
    public float followSpeed = 8f;    // Higher = snappier, lower = smoother
    public Vector3 offset;            // Offset from camera

    void Update()
    {
        if (headCamera == null) return;

        Vector3 targetPosition = headCamera.position + headCamera.TransformDirection(offset);

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );
    }
}
