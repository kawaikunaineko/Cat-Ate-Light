using UnityEngine;

public class LightOrb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.orbsCollectedNumber++;

            FindFirstObjectByType<ScoreManager>().UpdateScore();

            Destroy(gameObject);
        }
    }
}