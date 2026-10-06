using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = 0f;
        float turn = 0f;

        if (Input.GetKey(KeyCode.W))
            move = 1f;

        if (Input.GetKey(KeyCode.S))
            move = -1f;

        if (Input.GetKey(KeyCode.A))
            turn = -1f;

        if (Input.GetKey(KeyCode.D))
            turn = 1f;

        transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime);

        CharacterController controller = GetComponent<CharacterController>();
        controller.Move(transform.forward * move * moveSpeed * Time.deltaTime);

        bool isMoving = move != 0f || turn != 0f;
        animator.SetBool("IsRunning", isMoving);
    }
}