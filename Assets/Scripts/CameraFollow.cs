using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 19, 0);

    void LateUpdate()
    {
        // Put the camera at the target's position plus the offset
        transform.position = target.position + offset;
    }
}