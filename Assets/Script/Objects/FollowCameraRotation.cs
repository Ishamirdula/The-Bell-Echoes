using UnityEngine;

public class FollowCameraRotation : MonoBehaviour
{
    public Transform cameraTransform;

    void LateUpdate()
    {
        transform.rotation = cameraTransform.rotation;
    }
}