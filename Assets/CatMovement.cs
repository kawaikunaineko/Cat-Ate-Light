using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    public Transform cameraTransform;

    private Animator animator;
    private CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Get camera directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Keep movement on the ground
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculate movement direction
        Vector3 movement = forward * vertical + right * horizontal;

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // Move cat
        controller.Move(movement * moveSpeed * Time.deltaTime);

        // Rotate cat toward movement direction
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Animation
        bool isMoving = movement.magnitude > 0f;

        if (animator != null)
        {
            animator.SetBool("IsRunning", isMoving);
        }
    }
}