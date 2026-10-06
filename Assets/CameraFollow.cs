using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float distance = 3f;
    public float height = 2f;

    public float mouseSensitivity = 3f;

    private float rotationX = 20f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationY += mouseX * mouseSensitivity;
        rotationX -= mouseY * mouseSensitivity;

        rotationX = Mathf.Clamp(rotationX, -20f, 60f);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        Vector3 offset = rotation * new Vector3(0f, 0f, -distance);

        transform.position = target.position + Vector3.up * height + offset;

        transform.LookAt(target.position + Vector3.up * height);
    }
}