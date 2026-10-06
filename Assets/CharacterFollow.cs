using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public Transform target;

    public float followSpeed = 3f;
    public float stoppingDistance = 2f;
    public float behindDistance = 3f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null)
            return;

        // Position behind the cat
        Vector3 behindPosition =
            target.position - target.forward * behindDistance;

        float distance = Vector3.Distance(
            transform.position,
            behindPosition
        );

        if (distance > stoppingDistance)
        {
            Vector3 direction = behindPosition - transform.position;

            direction.y = 0f;
            direction.Normalize();

            // Move enemy
            transform.position +=
                direction * followSpeed * Time.deltaTime;

            // Turn enemy toward cat
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                10f * Time.deltaTime
            );

            if (animator != null)
            {
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }
}