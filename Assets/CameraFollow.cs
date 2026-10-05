using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cat;
    public float zOffset = -2.5f;
    public float followSpeed = 2f;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            cat.position.z + zOffset
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );
    }
}