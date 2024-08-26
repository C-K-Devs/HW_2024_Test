using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;
    public TextMeshProUGUI scoreText; // Reference to the UI Text component to display the score

    void Awake()
    {
        // Ensure there is only one instance of the ScoreManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to increase the score
    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    // Method to update the score display
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Method to reset the score (e.g., when the game restarts)
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
