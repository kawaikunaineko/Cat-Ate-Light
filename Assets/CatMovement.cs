using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float laneDistance = 3f;
    public float moveSpeed = 10f;

    private int currentLane = 0;

    void Update()
    {
        transform.Translate(Vector3.forward * 2f * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentLane--;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            currentLane++;

        currentLane = Mathf.Clamp(currentLane, -1, 1);

        Vector3 targetPosition = new Vector3(
            currentLane * laneDistance,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }
}