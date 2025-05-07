using UnityEngine;

public class BackgroundFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = new Vector3(cameraTransform.position.x + offset.x,
                                         cameraTransform.position.y + offset.y,
                                         transform.position.z);
    }
}
