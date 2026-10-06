using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 3f;
    public float stoppingDistance = 2f;

    void Update()
    {
        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > stoppingDistance)
        {
            Vector3 direction = target.position - transform.position;

            direction.y = 0f;

            direction.Normalize();

            transform.position += direction * followSpeed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                10f * Time.deltaTime
            );
        }
    }
}