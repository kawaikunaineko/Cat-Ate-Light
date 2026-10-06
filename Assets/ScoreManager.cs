using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int orbsCollectedNumber = 0;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        orbsCollectedNumber = 0;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "SCORE : " + orbsCollectedNumber;
    }
}