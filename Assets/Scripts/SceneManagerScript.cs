using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; // For displaying the final score in the Game Over scene
    private int finalScore;

    public void Start()
    {
        finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        DisplayFinalScore();
    }

    public void StartGame()
    {

        finalScore = 0; // Reset score at the start of the game
        SceneManager.LoadScene("MainScene"); // Load your game scene
    }
    public void DisplayFinalScore()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = "Score : " + finalScore.ToString();
        }
    }

    public void ResetGame()
    {
        ScoreManager.instance = null;
        SceneManager.LoadScene("StartScene"); // Go back to the start scene
    }
}
